clear variables; clc;

s = load("lab6_3.mat");

id = struct("u",s.id.InputData,"y",s.id.OutputData,"t",1:length(s.id.InputData));
val = struct("u",s.val.InputData,"y",s.val.OutputData,"t",length(s.id.InputData)+1:length(s.id.InputData)+length(s.val.InputData));

figure, 
subplot(1,2,1);plot(id.t,id.u); title('Identification data');
subplot(1,2,2);plot(val.t,val.u); title('Validation data'); 
%% Identification data
na = 1;
nb = 1;
nk = 0;

phi_id = [];
for i = 1:length(id.t)
    for j = 1:na
        phi_id(i,j) = -id.y(i-na+1);
    end
    for j = na+1:na+nb
        phi_id(i,j) = id.u(i-nb+1);
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
phi_val = [];
for i = 1:length(val.t)
    for j = 1:na
        phi_val(i,j) = -val.y(i-na+1);
    end
    for j = na+1:na+nb
        phi_val(i,j) = val.u(i-nb+1);
    end
end

y_val_cap = phi_val*theta;

mse_val = 1/length(val.y)*sum((y_val_cap-val.y).^2);

figure, 
plot(val.t,val.y,val.t,y_val_cap); title('Output for validation data and model, Validation MSE = ',num2str(mean(mse_val)));
xlabel('Time'); ylabel('Output');

pred = [];
for i = 1:length(val.t)
    for j = 1:na+nb
        if (i-j<=0)
            pred(i,j) = 0;
        else 
            pred(i,j) = val.y(i-j);
        end
    end
end

mse_pred = 1/length(val.y)*sum((pred*theta-val.y).^2);

figure, 
plot(val.t,val.y,val.t,-pred*theta); title('Output for prediction data and model, Validation MSE = ',num2str(mean(mse_pred)));
xlabel('Time'); ylabel('Output');