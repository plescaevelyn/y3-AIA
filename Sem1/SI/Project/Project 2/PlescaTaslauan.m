clear variables; clc;

s = load('iddata-09.mat'); % loading the data

m = 1; % maximum order of the dynamics, the polynomial degree

na = 3; % configurable 
nb = 3; % configurable 
nk = 0;

idlen = length(s.id);
vallen = length(s.val);

figure,
subplot(2,1,1); plot(s.id);
title('Identification data');
subplot(2,1,2); plot(s.val);
title('Validation data');
%% Prediction
% uses the knowledge of the real delayed outputs of the system

% Identification data
phi_id = zeros(length(s.id.InputData),na+nb);
for i = 1:length(s.id.InputData)
    % phi_id(1) = 1;
    for mm = 1:m
        for j = 1:na
            if (i-j>0)
                phi_id(i,j) = -1*s.id.OutputData(i-j)^mm;
            end
        end
        for j = na+1:na+nb
            if (i-j>0)
                phi_id(i,j) = s.id.OutputData(i-j)^mm;
            end
        end
    end 
end

y = s.id.OutputData;
theta = phi_id\y;
y_cap = phi_id*theta;

mse_id = 1/length(s.id.OutputData)*sum((y_cap-s.id.OutputData).^2)

figure, 
plot(length(s.id.OutputData),s.id.OutputData,length(s.id.OutputData),y_cap,'*'); title('Output for identification data and model, Identification MSE = ',num2str(mean(mse_id)));
xlabel('Time'); ylabel('Output');

% Validation data
phi_val = zeros(length(s.val.OutputData),na+nb);
for i = 1:length(s.val.OutputData)
    for mm = 1:m
       for j = 1:na
            if (i-j>0)
                phi_val(i,j) = -1*s.val.OutputData(i-j+1);
            end
        end
        for j = na+1:na+nb
            if (i-j>0)
                phi_val(i,j) = s.val.InputData(i-j+na);
            end
        end
    end
end

y_val_cap = phi_val*theta;

mse_val = 1/length(s.val.OutputData)*sum((y_val_cap-s.val.OutputData).^2);

figure, 
plot(length(s.val.OutputData),s.val.OutputData,length(s.val.OutputData),y_val_cap,'*'); title('Output for validation data and model, Validation MSE = ',num2str(mean(mse_val)));
xlabel('Time'); ylabel('Output');
%% Simulation
len = length(s.val.InputData);
phi = zeros(len,na+nb);
ysim = zeros(len,1);

for i = 2:len
    for mm = 1:m
        for j = 1:na
            if (i-j>0)
                phi(i,j) = -1*ysim(i-j)^mm;
            end
        end
        for k = na+1:na+nb
            if (na+i-k>0)
                phi(i,k) = s.val.InputData(na+i-k)^mm;
            end
        end
    end
    ysim(i) = phi(i,:)*theta;
end

theta = phi\s.val.OutputData;
yhatsim = phi*theta;

mse_pred = 1/length(s.val.OutputData)*sum((s.val.OutputData-ysim).^2);

figure, 
plot(length(s.val.OutputData),s.val.OutputData,length(s.val.OutputData),yhatsim,'*'); title('Output for prediction data and model, Validation MSE = ',num2str(mean(mse_pred)));
xlabel('Time'); ylabel('Output');