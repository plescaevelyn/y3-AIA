clear variables; clc; close all;

s = load('iddata-09.mat');

figure,
subplot(211); plot(s.id); title("Identification");
subplot(212); plot(s.val); title("Validation");

m = 3;
na = 1; % configurabil
nb = 1;

phi = phi_func(s,m);
theta = phi\s.id.OutputData;
ycap = phi*theta;

mse_id = 1/length(s.id.OutputData)*sum((ycap-s.id.OutputData).^2);

figure, 
plot(length(s.id.OutputData),s.id.OutputData,length(s.id.OutputData),ycap,'*'); title('Output for identification data and model, Identification MSE = ',num2str(mean(mse_id)));
xlabel('Time'); ylabel('Output');

function phi = phi_func(s,m)
    switch m
        case 1
            phi_fun = @(k)([s.id.OutputData(k),s.id.InputData(k)]);
        case 2
            phi_fun = @(k)([s.id.OutputData(k),s.id.InputData(k),s.id.OutputData(k)^2,s.id.InputData(k)^2,s.id.InputData(k)*s.id.InputData(k)]);
        case 3
            phi_fun = @(k)([s.id.OutputData(k),s.id.InputData(k),s.id.OutputData(k)^2,s.id.InputData(k)^2,s.id.OutputData(k)^3,s.id.InputData(k)^3,s.id.InputData(k)*s.id.InputData(k)]);
    end 

    phi = [];

    for i = 1:length(s.id.OutputData)
        phi = [phi;phi_fun(i)];
    end
end