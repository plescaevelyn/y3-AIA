clear variables; clc;

s = load('iddata-09.mat'); % loading the data

m = 1; % maximum order of the dynamics, the polynomial degree

na = 1; % configurable 
nb = 1; % configurable 
nk = 1;

idlen = length(s.id);
vallen = length(s.val);

figure,
subplot(2,1,1); plot(s.id);
title('Identification data');
subplot(2,1,2); plot(s.val);
title('Validation data');
%% Prediction
% uses the knowledge of the real delayed outputs of the system
phi_id = zeros(length(s.id.InputData),na+nb);
for i = 1:length(s.id.InputData)
    for mm = 1:m
        for j = 1:na
            if (i-j<=0)
                phi_id(i,j) = 0;
            else
                phi_id(i,j) = -1*s.id.OutputData(i-j);
            end
        end
        for j = na+1:na+nb
            if (i-j<=0)
                phi_id(i,j) = 0;
            else
                phi_id(i,j) = s.id.OutputData(i-j);
            end
        end
    end 
end

y = s.id.OutputData;
theta = phi_id\y;
y_cap = phi_id*theta;

mse_id = 1/length(s.id.OutputData)*sum((y_cap-s.id.OutputData).^2);

figure, 
plot(length(s.id.OutputData),s.id.OutputData,length(s.id.OutputData),y_cap); title('Output for identification data and model, Identification MSE = ',num2str(mean(mse_id)));
xlabel('Time'); ylabel('Output');