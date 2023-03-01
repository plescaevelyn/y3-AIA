clear variables; clc;
%% 1st point
hf = tf(2,[1 1]);

% module
t = 1;
hd = tf(1,[2*t^2 2*t])
hr = hd/hf;
minreal(hr)
wn = 1/t/sqrt(2)
zeta = 1/sqrt(2)
%ts = 4/zeta/wn
ts = 8*t
sigma = 0.043
figure,
step(hd); feedback(hd,1);

% symmetry
hd = tf([4*t 1],[8*t^3 8*t^2])
hr = hd/hf;
minreal(hr)
ts = 11*t
sigma = 0.43

figure,
step(hd); feedback(hd,1);
%% 2nd point
hs = tf(2,[1 1 0]);

% module
t = 1;
hd = tf(1,[2*t^2 2*t])
hr = hd/hf;
minreal(hr)
wn = 1/t/sqrt(2)
zeta = 1/sqrt(2)
%ts = 4/zeta/wn
ts = 8*t
sigma = 0.043
figure,
step(hd); feedback(hd,1);

% symmetry
hd = tf([4*t 1],[8*t^3 8*t^2])
hr = hd/hf;
minreal(hr)
ts = 11*t
sigma = 0.43

figure,
step(hd); feedback(hd,1);
%% 3rd point
hs = tf(2,[10 11 1]);

% module
t = 1;
hd = tf(1,[2*t^2 2*t])
hr = hd/hf;
minreal(hr)
wn = 1/t/sqrt(2)
zeta = 1/sqrt(2)
%ts = 4/zeta/wn
ts = 8*t
sigma = 0.043
figure,
step(hd); feedback(hd,1);

% symmetry
hd = tf([4*t 1],[8*t^3 8*t^2])
hr = hd/hf;
minreal(hr)
ts = 11*t
sigma = 0.43

figure,
step(hd); feedback(hd,1);
%% 4th point
hs = tf(2,[10 21 12 1]);

% module
t = 2;
hd = tf(1,[2*t^2 2*t])
hr = hd/hf;
minreal(hr)
wn = 1/t/sqrt(2)
zeta = 1/sqrt(2)
%ts = 4/zeta/wn
ts = 8*t
sigma = 0.043
figure,
step(hd); feedback(hd,1);

% symmetry
hd = tf([4*t 1],[8*t^3 8*t^2])
hr = hd/hf;
minreal(hr)
ts = 11*t
sigma = 0.43

figure,
step(hd); feedback(hd,1);
%% 5th point
hs = tf(2,[200 230 31 1]);

% module
t = 1;
hd = tf(1,[2*t^2 2*t])
hr = hd/hf;
minreal(hr)
wn = 1/t/sqrt(2)
zeta = 1/sqrt(2)
%ts = 4/zeta/wn
ts = 8*t
sigma = 0.043
figure,
step(hd); feedback(hd,1);

% symmetry
hd = tf([4*t 1],[8*t^3 8*t^2])
hr = hd/hf;
minreal(hr)
ts = 11*t
sigma = 0.43

figure,
step(hd); feedback(hd,1);
%% 6th point
hs = tf(2,[100 220 141 22 1]);

% module
t = 2;
hd = tf(1,[2*t^2 2*t])
hr = hd/hf;
minreal(hr)
wn = 1/t/sqrt(2)
zeta = 1/sqrt(2)
%ts = 4/zeta/wn
ts = 8*t
sigma = 0.043
figure,
step(hd); feedback(hd,1);

% symmetry
hd = tf([4*t 1],[8*t^3 8*t^2])
hr = hd/hf;
minreal(hr)
ts = 11*t
sigma = 0.43

figure,
step(hd); feedback(hd,1);
