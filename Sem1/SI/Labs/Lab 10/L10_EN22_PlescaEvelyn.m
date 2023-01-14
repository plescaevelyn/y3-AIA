clear variables; clc;
close all;
%% Loading and plotting the data
s = load('lab10_3.mat');

na = 3*s.n; % order of A
nb = 3*s.n; % order of B
nk = 1; % delay

figure,
subplot(211); plot(s.id); title("Identification data");
subplot(212); plot(s.val); title("Validation data");
%% Creating the model using the whole dataset
theta = zeros(na+nb,1);
w = zeros(na+nb,1); % weighting function
phi = zeros(length(s.id.InputData),na+nb); % regressors vector
p_inv = 100*eye(na+nb); % initialising P^-1
A = [1,zeros(1,na-1)];
B = zeros(1,nb);

% creating phi
for i = 1:length(s.id.InputData)
    for j = 1:na
        if (i > j)
            phi(i,j) = -1*s.id.OutputData(i-j);
        end
    end
    for j = na+1:na+nb
        if (i+na > j)
            phi(i,j) = s.id.InputData(i-j+na);
        end
    end
end

% forming the RARX regressor vector 
for k = 2:length(s.id.InputData)
    e(k) = s.id.OutputData(k) - phi(k,:)*theta; % computing the error (a scalar)
    p_inv = p_inv - p_inv*phi(k,:)'*phi(k,:)*p_inv/(1+phi(k,:)*p_inv*phi(k,:)'); % updating the inverse using the Sherman-Morrison formula
    w = p_inv*phi(k,:)'; % computing the weights
    theta = theta + w*e(k); % updating parameters
end

% creating the polynomials used in the idpoly function
for k = 2:na+1
    A(k) = theta(k-1);
    B(k) = theta(k+nb-1);
end

RARXmodel = idpoly(A,B,[],[],[],0,s.id.Ts);

figure,
subplot(211);
compare(RARXmodel,s.id);title('Comparison for the RARX model with the identification data for the whole dataset');
subplot(212);
compare(RARXmodel,s.val);title('Comparison for the RARX model with the validation data for the whole dataset');
%% Creating the model using 10% of the whole dataset
N = round(length(s.id.InputData)/10);
theta = zeros(na+nb,1);
w = zeros(na+nb,1); % weighting function
phi = zeros(N,na+nb); % regressors vector
p_inv = 100*eye(na+nb); % initialising P^-1
A = [1,zeros(1,na-1)];
B = zeros(1,nb);

% creating phi
for i = 1:N
    for j = 1:na
        if (i > j)
            phi(i,j) = -1*s.id.OutputData(i-j);
        end
    end
    for j = na+1:na+nb
        if (i+na > j)
            phi(i,j) = s.id.InputData(i-j+na);
        end
    end
end

% forming the RARX regressor vector 
for k = 2:N
    e(k) = s.id.OutputData(k) - phi(k,:)*theta; % computing the error (a scalar)
    p_inv = p_inv - p_inv*phi(k,:)'*phi(k,:)*p_inv/(1+phi(k,:)*p_inv*phi(k,:)'); % updating the inverse using the Sherman-Morrison formula
    w = p_inv*phi(k,:)'; % computing the weights
    theta = theta + w*e(k); % updating parameters
end

% creating the polynomials used in the idpoly function
for k = 2:na+1
    A(k) = theta(k-1);
    B(k) = theta(k+nb-1);
end

RARXmodel = idpoly(A,B,[],[],[],0,s.id.Ts);

figure,
subplot(211);
compare(RARXmodel,s.id);title('Comparison for the RARX model with the identification data for 10% of the dataset');
subplot(212);
compare(RARXmodel,s.val);title('Comparison for the RARX model with the validation data for 10% of the dataset');
%% Conclusions on running the RARX model on the whole dataset vs 10% of it
% We can clearly see that running the RARX model on the whole dataset works
% better and with a better precision than doing it on only 10% of the
% dataset, as in the identification data the model of the whole dataset is
% better with 4% (approx 96% for the whole dataset and 92% for 10% of the
% dataset) and better with 2% when comparing the model with the validation
% data (approx 92% for the whole dataset and 91% for 10% of the dataset)
% I think this is happening because by processing a larger amount of data,
% our model is more precise
%% Creating the RARX model using the rarx function for the whole dataset
% theta2 = rarx(s.id,[na,nb,1],'ff',1,zeros(na+nb,1),100*eye(na+nb)); % creating our theta
% RARXmodel2 = idpoly([1 theta2(length(s.id),1:na)],[0 theta2(length(s.id),na+1:na+nb)],[],[],[],0,s.id.Ts);

% figure,
% compare(RARXmodel2,s.val);title('Comparison for the second RARX model with the validation data for the whole dataset');
%% Creating the RARX model using the rarx function for 10% of the dataset
% theta2 = rarx(s.id,[na,nb,1],'ff',1,zeros(na+nb,1),100*eye(na+nb)); % creating our theta
% RARXmodel2 = idpoly([1 theta2(length(s.id),1:na)],[0 theta2(length(s.id),na+1:na+nb)],[],[],[],0,s.id.Ts);

% figure,
% compare(RARXmodel2,s.val(1:N));title('Comparison for the second RARX model with the validation data for 10% of the dataset');