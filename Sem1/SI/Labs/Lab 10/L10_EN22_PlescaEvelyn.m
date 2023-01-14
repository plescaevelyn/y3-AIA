clear variables; clc;
close all;
%% Loading and plotting the data
s = load('lab10_3.mat');

na = 3*s.n;
nb = 3*s.n;
nk = 0;

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
    p_inv = p_inv - p_inv*phi(k,:)'*phi(k,:)*p_inv/(1+phi(k,:)*p_inv*phi(k,:)'); % updating the inverse using the Sherrison-Morrins formula
    w = p_inv*phi(k,:)'; % computing the weights
    theta = theta + w*e(k); % updating parameters
end

% creating the polynomials used in the idpoly function
for k = 2:na+1
    A(k) = theta(k-1);
    B(k) = theta(k+nb-1);
end

RARXmodel = idpoly(A,B,[],[],[],0,s.id.Ts);
% RARXmodel2 = rarx(s.id,[na,nb,1],'ff',1,zeros(na+nb,1),100*eye(na+nb));

figure,
subplot(211);
compare(RARXmodel,s.id);title('Comparison for the RARX model with the identification data');
subplot(212);
compare(RARXmodel,s.val);title('Comparison for the RARX model with the validation data');