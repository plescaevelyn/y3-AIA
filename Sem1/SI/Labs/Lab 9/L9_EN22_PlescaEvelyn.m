clear variables; clc; close all;
%% Loading and plotting the data
s = load('lab9_3.mat');

figure,
subplot(211); plot(s.id); title("Identification data");
subplot(212); plot(s.val); title("Validation data");
%% Creating the ARX model
na = s.n;
nb = s.n;
nk = 0;

% Creating the ARX model using the pre-implemented function
ARXmodel = arx(s.id,[na,nb,nk]);

% Identification data
phi_id = zeros(length(s.id.InputData),na+nb);
for i = 1:length(s.id.InputData)
    for j = 1:na
        if (i-j > 0)
            phi_id(i,j) = -1*s.id.OutputData(i-j);
            phi_id(i,j+na) = s.id.InputData(i-j);
        end
    end
end

theta = phi_id\s.id.OutputData;
theta_id = theta;
y_cap = phi_id*theta;

mse_id = 1/length(s.id.OutputData)*sum((y_cap-s.id.OutputData).^2);

figure, 
subplot(311);
plot(1:length(s.id.InputData),s.id.OutputData,1:length(s.id.InputData),y_cap); title('Output for identification data and model of the ARX model, Identification MSE = ',num2str(mean(mse_id)));
xlabel('Time'); ylabel('Output');

% Validation data
phi_val = zeros(length(s.val.InputData),na+nb);
for i = 1:length(s.val.InputData)
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

y_val_cap = phi_val*theta;

mse_val = 1/length(s.val.OutputData)*sum((y_val_cap-s.val.OutputData).^2);

subplot(312)
plot(1:length(s.val.InputData),s.val.OutputData,1:length(s.val.InputData),y_val_cap); title('Output for validation data and model of the ARX model, Validation MSE = ',num2str(mean(mse_val)));
xlabel('Time'); ylabel('Output');
% Simulation
phi = zeros(length(s.val.InputData),na+nb);
ysim = zeros(length(s.val.InputData),1);

for i = 2:length(s.val.InputData)
    for j = 1:na
        if (i-j>0)
            phi(i,j) = -1*ysim(i-j);
        end
    end
    for k = na+1:na+nb
        if (na+i-k>0)
            phi(i,k) = s.val.InputData(na+i-k);
        end
    end
    ysim(i) = phi(i,:)*theta;
end

theta = phi\s.val.OutputData;
yhatsim = phi*theta;

mse_pred = 1/length(s.val.OutputData)*sum((s.val.OutputData-ysim).^2);

subplot(313);
plot(1:length(s.val.InputData),s.val.OutputData,1:length(s.val.OutputData),yhatsim); title('Output for prediction data and model of the ARX model, Validation MSE = ',num2str(mean(mse_pred)));
xlabel('Time'); ylabel('Output');
%% Creating the IV model
phi = zeros(na+nb,na+nb);
phi_tilda = zeros(na+nb, 1);
z = zeros(na+nb, 1);
y_tilda = zeros(na+nb, 1);

for i = 1:length(ysim)
    for j = 1 : na
        if (i > j)
            z(j) = ysim(i-j);
            z(j+na) = s.id.InputData(i-j);
        end
    end

    y_tilda = y_tilda + z*s.id.OutputData(i);
    phi_tilda = phi_tilda + z*phi_id(i,:);
end

N = length(ysim);
y_tilda = 1/N*y_tilda;
phi_tilda = 1/N*phi_tilda;
theta = phi_tilda\y_tilda;

Ahat = theta(1:na);
Bhat = theta(na+1:na+nb);

IVmodel = idpoly([1 Ahat'],[0 Bhat'],[],[],[],0,s.id.Ts);

figure,
compare(IVmodel,s.id);title('Comparison for the IV model');
%% Comparing the quality of the two models (ARX and IV)
figure,
subplot(211); compare(IVmodel,s.val);
title('IV Model');
subplot(212); compare(ARXmodel,s.val);
title('ARX Model')