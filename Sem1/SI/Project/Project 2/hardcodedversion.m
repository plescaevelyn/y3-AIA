% this version only works for na=nb=1!
clear variables; clc; close all;
%% Loading and plotting the initial data
s = load('iddata-09.mat');

figure,
subplot(211); plot(s.id); title("Identification data");
subplot(212); plot(s.val); title("Validation data");

m = 3;
na = 1; % configurabil
nb = 1;
%% Prediction on identification data
phi = phi_func(s.id,m);
theta = phi\s.id.OutputData;
ycap = phi*theta;

mse_id = 1/length(s.id.OutputData)*sum((ycap-s.id.OutputData).^2);

figure, 
plot(1:length(s.id.OutputData),s.id.OutputData,1:length(s.id.OutputData),ycap); title('Output for identification data and model, Identification MSE = ',num2str(mean(mse_id)));
xlabel('Time'); ylabel('Output');
%% Prediction on validation data
phi = phi_func(s.val,m);
theta = phi\s.val.OutputData;
ycap = phi*theta;

mse_id = 1/length(s.val.OutputData)*sum((ycap-s.val.OutputData).^2);

figure, 
plot(1:length(s.val.OutputData),s.val.OutputData,1:length(s.val.OutputData),ycap); title('Output for identification data and model, Identification MSE = ',num2str(mean(mse_id)));
xlabel('Time'); ylabel('Output');
%% Function for calculating phi
function phi = phi_func(s,m)
    switch m
        case 1
            phi_fun = @(k)([s.OutputData(k),s.InputData(k)]);
        case 2
            % phi_fun = @(k)([s.OutputData(k),s.id.InputData(k),s.id.OutputData(k)^2,s.id.InputData(k)^2,s.id.InputData(k)*s.id.InputData(k)]);
            phi_fun = @(k)([1,s.OutputData(k),s.InputData(k),s.OutputData(k).^2,s.InputData(k).^2]);
        case 3
            phi_fun = @(k)([1,s.OutputData(k),s.InputData(k),s.OutputData(k).^2,s.InputData(k).^2,s.OutputData*s.InputData.^2,s.OutputData.^2*s.InputData,s.OutputData(k).^3,s.InputData(k).^3]);
    end 

    phi = [];

    for i = 1:length(s.OutputData)
        phi = [phi;phi_fun(i)];
    end
end