clear all
clc
hf = tf(3.5, [0.5, 1, 0]);
m = 0.10;
xi = abs(log(m))/sqrt(pi^2+log(m)^2);
A = 1/sqrt(2)/4/xi/xi;
Adb = 20*log10(A);
figure
bode(hf); hold on
F = 1.85; %read from bode
Kp = 10^((Adb-F)/20);
hd = Kp*hf;
bode(hd); hold off

figure
step(feedback(hd,1));