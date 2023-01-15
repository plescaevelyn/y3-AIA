clear variables; clc;

s = load("lab6_3.mat");

id = struct("u",s.id.InputData,"y",s.id.OutputData,"t",1:length(s.id.InputData));
val = struct("u",s.val.InputData,"y",s.val.OutputData,"t",length(s.id.InputData)+1:length(s.id.InputData)+length(s.val.InputData));

figure, 
subplot(1,2,1);plot(id.t,id.u); title('Identification data');
subplot(1,2,2);plot(val.t,val.u); title('Validation data'); 
%% Identification data
na = 20;
nb = 20;

phi_id = zeros(length(id.u),na+nb);
for i = 1:length(id.t)
    for j = 1:na
        if (i > j)
            phi_id(i,j) = -1*id.y(i-j);
            phi_id(i,j+na) = id.u(i-j);
        end
    end
end

y = id.y;
theta = phi_id\y;
y_cap = phi_id*theta;

mse_id = 1/length(id.y)*sum((y_cap-id.y).^2);

figure, 
plot(id.t,id.y,id.t,y_cap); title('Output for identification data and model, Identification MSE = ',num2str(mean(mse_id)));
xlabel('Time'); ylabel('Output');
%% Validation data
phi_val = zeros(length(val.t),na+nb);
for i = 1:length(val.t)
    for j = 1:na
        if (i > j)
            phi_val(i,j) = -1*val.y(i-j+1);
            phi_val(i,j+na) = val.u(i-j);
        end
    end
end

y_val_cap = phi_val*theta;

mse_val = 1/length(val.y)*sum((y_val_cap-val.y).^2);

figure, 
plot(val.t,val.y,val.t,y_val_cap); title('Output for validation data and model, Validation MSE = ',num2str(mean(mse_val)));
xlabel('Time'); ylabel('Output');
%% Simulation
len = length(val.u);
phi = zeros(len,na+nb);
ysim = zeros(len,1);

for i = 2:len
    for j = 1:na
        if (i > j)
            phi(i,j) = -1*ysim(i-j);
            phi(i,j+na) = val.u(i-j);
        end
    end
    ysim(i) = phi(i,:)*theta;
end


theta = phi\val.y;
yhatsim = phi*theta;

mse_pred = 1/length(val.y)*sum((val.y-ysim).^2);

figure, 
plot(val.t,val.y,val.t,yhatsim); title('Output for prediction data and model, Validation MSE = ',num2str(mean(mse_pred)));
xlabel('Time'); ylabel('Output');