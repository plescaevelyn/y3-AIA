%% First Order Response
clc; clear variables;

s1 = load("lab3_order1_3.mat");

figure,
subplot(2,1,1); plot(s1.t,s1.data.InputData); title(s1.data.InputName);
subplot(2,1,2); plot(s1.t,s1.data.OutputData); title(s1.data.OutputName);

id = struct("u",s1.data.InputData(1:100),"y",s1.data.OutputData(1:100),"t",s1.t(1:100));
val = struct("u",s1.data.InputData(201:500),"y",s1.data.OutputData(201:500),"t",s1.t(201:500));

y_ss = 1/11*sum(id.y(90:100,:))
u_ss = 1/11*sum(id.u(90:100,:))
y0 = 0;
u0 = 0;

k = (y_ss-y0)/(u_ss-u0)
hs = tf(k,[63*y_ss/100 1])

y_id_cap = lsim(hs,id.u,id.t);
y_val_cap = lsim(hs,val.u,val.t);

mse_id = 1/100*(id.y)*sum((y_id_cap-id.y).^2);
mse_val = 1/300*(val.y)*sum((y_val_cap-val.y).^2);

figure,
subplot(2,1,1);
plot(id.t,id.y,id.t,y_id_cap); % title("Identification MSE = " + string(mse_id))
subplot(2,1,2);
plot(val.t,val.y,val.t,y_val_cap); % title("Validation MSE = " + string(mse_val))

%% Second Order Response
clear variables;

s2 = load("lab3_order2_3.mat");

figure,
subplot(2,1,1); plot(s2.t,s2.data.InputData); title(s2.data.InputName);
subplot(2,1,2); plot(s2.t,s2.data.OutputData); title(s2.data.OutputName);

id = struct("u",s2.data.InputData(1:100),"y",s2.data.OutputData(1:100),"t",s2.t(1:100));
val = struct("u",s2.data.InputData(201:500),"y",s2.data.OutputData(201:500),"t",s2.t(201:500));

y_ss = 1/11*sum(id.y(90:100,:));
u_ss = 1/11*sum(id.u(90:100,:));
y0 = 0;
u0 = 0;

y_max = max(id.y)
y_min = min(id.y)
y1 = 9.07
y2 = 4.36
y3 = 7.01
t1 = 3.5
t3 = 10.15

k = (y_ss-y0)/(u_ss-u0) % gain
M = (y1-y_ss)/(y_ss-y0) % overshoot in nonzero initial conditions
M1 = (y_ss-y2)/(y1-y_ss)
zeta = log(1/M1)/(sqrt(pi^2+log(M1)^2)) % damping factor
wn = abs((2*pi)/((t3-t1)*sqrt(1-zeta^2)))% natural frequency
wn1 = 2/(t3-t1)*sqrt(pi^2+(log(M1))^2)
hs = tf(k*wn^2,[1 2*zeta*wn wn^2])

y_id_cap = lsim(hs,id.u,id.t);
y_val_cap = lsim(hs,val.u,val.t);

mse_id = 1/100*(id.y)*sum((y_id_cap-id.y).^2);
mse_val = 1/300*(val.y)*sum((y_val_cap-val.y).^2);

figure,
subplot(2,1,1);
plot(id.t,id.y,id.t,y_id_cap); % title("Identification MSE = " + string(mse_id))
subplot(2,1,2);
plot(val.t,val.y,val.t,y_val_cap); % title("Validation MSE = " + string(mse_val))
