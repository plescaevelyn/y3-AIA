clc
%% 
k = 1;
tau_m = 0.2;
w = logspace(-1,3,1e5);
H = tf(k*[-.5,1],[1 0],'IOdelay',tau_m)
nyquist(H,w); shg;
hold off;
%%
k = 3;
Hol = H*k;
nyquist(Hol,w); shg;
nyquist(Hol);
hold off;
%%
Hcl = feedback(Hol,1)
t = linspace(0,4,1e2);
step(Hcl,t)
nyquist(Hcl,w); 
hold off;

nyquist(Hol,w); hold on;
line