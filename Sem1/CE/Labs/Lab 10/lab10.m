%% Cascade Control
clear variables; clc

hf1 = tf(2.4,conv([0.5 1],[50 1])) % 2.4 e constanta parazita
hf2 = tf(8.6,conv([0.01 1],[0.6 1]))

% vrem sa rejectam o rampa => avem nevoie de doua integratoare in Hr

% daca nu ni se spun performantele, trebuie sa facem un sistem stabil
% (verificam cu marginea de faza) 

% la kessler, metoda modulului are un integrator si a simetriei are 2
% integratoare

% bucla interna => metoda modulului, bucla externa => metoda simetriei

% module
t1 = 0.01;
hd1 = tf(1,[2*t1^2 2*t1 0])
hr2 = hd1/hf2
hr = hd1/hf2;

hf = tf(hf1*hd1,1+hd1)
ho2 = hd1/(1+hd1)
T = 1/50;
t1 = 0.5 + T;

hd2 = tf([4*t1 1],[8*t1^3 8*t1^2])
ho1 = hd2/(1+hd2)
step(ho1); hold on;