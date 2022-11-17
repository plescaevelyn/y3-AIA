%% PI controller
clear all
clc

tr = 15;
hf = tf(3.5, [0.5 1 0]);
m = 0.10;
zeta = abs(log(m))/sqrt(pi^2+log(m)^2);
wn = 4/tr/zeta;
A = 1/sqrt(2)/4/zeta/zeta;
Adb = mag2db(A)

figure
bode(hf); hold on
F = 1.85; %read from bode
Kp = 10^((Adb-F)/20);
hd = Kp*hf;

ts = 5.17; % time when entering steady state
tsstar = 0.9;
Td = 0.5;

Tn = Td*tsstar/ts
Vr = Kp*ts/tsstar
Hpd = Vr*tf([Td 1],[Tn 1])

Hd2 = Hpd*hf;

bode(Hd2);

figure,
step(feedback(Hd2,1));

%% PID controller
