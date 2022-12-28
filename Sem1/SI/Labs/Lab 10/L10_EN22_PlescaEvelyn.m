% CITIT SI VERIFICAT DIN CURS
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
%% Predifining variables
theta_hat = zeros(na+nb,1);
p_inv = zeros(na+nb,na+nb);
w = zeros(na+nb,1); % weight
e = zeros(1,length(s.id.InputData));

% forming the ARX regressor vector 
phi = zeros(length(s.id.InputData),na+nb);
for k = 2:length(s.id.InputData)
    for j = 1:na
        if (k-j>0)
            phi(k,j) = -1*s.id.OutputData(k-j);
        end
    end
    for j = na+1:na+nb
        if (k-j>0)
            phi(k,j) = s.id.InputData(k-j);
        end
    end

    e(k) = s.id.OutputData(k) - phi(k)'*theta_hat(k-1); % computing the error (a scalar)
    p_inv(k) = p_inv(k-1) - p_inv(k-1)*phi(k)*phi(k)'*p_inv(k-1)/(1+phi(k)'*p_inv(k-1)*phi(k)); % updating the inverse
    w(k) = p_inv(k)*phi(k); % computing the weights
    theta_hat(k) = theta_hat(k-1)+w(k)*e(k); % updating parameters
end

rarx(s.id,na,nb,nk)