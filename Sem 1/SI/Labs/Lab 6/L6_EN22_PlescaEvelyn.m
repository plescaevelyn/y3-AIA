clear variables; clc;

s = load("lab6_3.mat");

figure, 
subplot(211);plot(1:length(s.id.OutputData),s.id.InputData); title('Identification data');
subplot(212);plot(1:length(s.val.OutputData),s.val.InputData); title('Validation data'); 
%% Identification data
na = 20;
nb = 20;

phi_id = zeros(length(s.id.InputData),na+nb);
for i = 1:length(s.id.OutputData)
    for j = 1:na
        if (i > j)
            phi_id(i,j) = -1*s.id.OutputData(i-j);
            phi_id(i,j+na) = s.id.InputData(i-j);
        end
    end
end

theta = phi_id\s.id.OutputData;
y_cap = phi_id*theta;

mse_id = 1/length(s.id.OutputData)*sum((y_cap-s.id.OutputData).^2);

figure, 
plot(1:length(s.id.OutputData),s.id.OutputData,1:length(s.id.OutputData),y_cap); title('Output for identification data and model, Identification MSE = ',num2str(mean(mse_id)));
xlabel('Time'); ylabel('Output');
%% Validation data
phi_val = zeros(length(s.val.OutputData),na+nb);
for i = 1:length(s.val.OutputData)
    for j = 1:na
        if (i > j)
            phi_val(i,j) = -1*s.val.OutputData(i-j);
            phi_val(i,j+na) = s.val.InputData(i-j);
        end
    end
end

y_val_cap = phi_val*theta;

mse_val = 1/length(s.val.OutputData)*sum((y_val_cap-s.val.OutputData).^2);

figure, 
plot(1:length(s.val.OutputData),s.val.OutputData,1:length(s.val.OutputData),y_val_cap); title('Output for validation data and model, Validation MSE = ',num2str(mean(mse_val)));
xlabel('Time'); ylabel('Output');
%% Simulation
phi = zeros(length(s.val.OutputData),na+nb);
ysim = zeros(length(s.val.OutputData),1);

for i = 2:length(s.val.OutputData)
    for j = 1:na
        if (i > j)
            phi(i,j) = -1*ysim(i-j);
            phi(i,j+na) = s.val.InputData(i-j);
        end
    end
    ysim(i) = phi(i,:)*theta;
end

theta = phi\s.val.OutputData;
yhatsim = phi*theta;

mse_pred = 1/length(s.val.OutputData)*sum((s.val.OutputData-ysim).^2);

figure, 
plot(1:length(s.val.OutputData),s.val.OutputData,1:length(s.val.OutputData),yhatsim); title('Output for prediction data and model, Validation MSE = ',num2str(mean(mse_pred)));
xlabel('Time'); ylabel('Output');