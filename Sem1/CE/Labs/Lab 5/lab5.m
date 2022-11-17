%% P controller
Hf = tf(3.5,[0.5 1 0]);

e_stp = 0;
sigma = 0.105;
tr = 15;
cv = 5;
sigmab = 15;

zeta = abs(log(sigma))/sqrt(log(sigma)^2+pi^2);
wn = 4/tr/zeta;

A = mag2db(1/4/sqrt(2)/zeta^2)
N = A
omegaf = 2 % pulsatia de frangere
omegat = 2.3 % pulsatia de taiere
F = 1.85;
R = N-F
R = db2mag(R)
kp = R

Hd = R*Hf;
Ho = tf([0 0 wn^2],[1 2*zeta*wn wn^2])
Hr = (Ho/(1-Ho))/Hf

figure,
bode(Hf)
grid; shg; hold on
bode(Hd)
hold off;

step(feedback(Hd,1))
%% PI controller
cvprim = 5
wn = 2;
cv = 9.86
u = cv
q = cvprim
kpi = q - u
uq = db2mag(cvprim) - db2mag(cv)
kpi = kp*db2mag(uq)
wt = wn/2/zeta
wz = 0.1*wt
wp = cv/cvprim*wz
Tz = 1/wz
Tp = 1/wp
hpi = kpi*tf([Tz,1],[Tp,1])
hd = Hf*hpi
bode(Hf); grid; shg; hold on; bode(hd)
