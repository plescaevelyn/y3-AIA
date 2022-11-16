%% a
hf = tf(3.5, [0.5, 1, 0]);
m = 0.15;
xi = abs(log(m))/sqrt(pi^2+log(m)^2);
A = 1/sqrt( 2)/4/xi/xi;
Adb = 20*log10(A);
ts = 4.06; %using only P controller
ts1 = 1; % desired
Kp = 0.5346; %using P controller
Kp1 = Kp*ts/ts1; % new gain needed
Td = 0.5; % = Tf
Tn = Td*ts1/ts;
figure
bode(hf); hold on
hc = tf(Kp1*[Td, 1], [Tn, 1]);

hd = hc*hf;
bode(hd); hold off

figure
step(feedback(hd,1));

%% b
hf = tf(3.5, [0.5, 1, 0]);
m = 0.15;
xi = abs(log(m))/sqrt(pi^2+log(m)^2);
A = 1/sqrt(2)/4/xi/xi;
Adb = 20*log10(A);
ts = 4.06; %using only P controller
ts1 = 2/xi/xi/15; % desired
Kp = 0.5346; %using P controller
Kp1 = Kp*ts/ts1; % new gain needed
Td = 0.5; % = Tf
Tn = Td*ts1/ts;
figure
bode(hf); hold on
hc = tf(Kp1*[Td, 1], [Tn, 1]);
hd = hc*hf;
bode(hd); hold off

figure
step(feedback(hd,1));