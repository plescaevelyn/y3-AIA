clear variables; clc;

hf = tf(2,conv([10 1],[5 1]),'IODelay',3)
figure,
bode(hf)
%% PI controller
sigma_k = 50;
-180+15+sigma_k
wc = 0.142;
Ti = 4/wc
kp = 1/db2mag(0.564);
hc = tf([kp*Ti kp],[Ti 0]);

figure,
bode(hc*hf)
figure,
step(feedback(hc*hf,1))
%% PD controller
sigma_k = 50;
beta = 0.1;
hc_phase = atand(1-beta/2/sqrt(beta))
hol_phase = -180+sigma_k
hp_phase = -180-hc_phase+sigma_k

wc = 0.318
mag = db2mag(-9.99)
td = 1/wc/sqrt(beta)
bode(hf)
kp = sqrt(beta)/mag
hc=kp*tf([td 1],[td*beta 1])

figure,
bode(hc*hf)
figure,
step(feedback(hc*hf,1))