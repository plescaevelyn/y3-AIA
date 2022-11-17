clear all
% PI controller
hf = tf(3.5, [0.02, 1, 0]);
m = 0.15;
xi = abs(log(m))/sqrt(pi^2+log(m)^2);
A = 1/sqrt(2)/4/xi/xi;
Adb = 20*log10(A);
figure
bode(hf); hold on
F = -26.1; %read from bode
Kp = 10^((Adb-F)/20);
hd = Kp*hf;
bode(hd); hold off

figure
step(feedback(hd,1));

cvdb = 33.3; %read
cv = 10^(cvdb/20);
wt = 37.1; %read
wz = 0.1*wt;
cv1 = 50;
cv1db = 20*log10(cv1);
wp = cv/cv1*wz;
Vr = Kp*10^((cv1db-cvdb)/20);
Hpi = Vr*tf([1/wz,1],[1/wp,1]);
Hd1 = Hpi*hf;
figure
bode(hd); hold on
bode(Hd1); hold off

t = 0: 0.1 : 100;
u = t;
viteza = lsim(feedback(Hd1, 1), u, t);
ev = t(end)-viteza(end)
cv11 = 1/ev;