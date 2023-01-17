clc;
clear variables;
H = tf(4,[1,0])
nyquist(H)
%% Simulate the response to a sinewave with w = wc 
wc = 4; % cut-off frequency
w = wc;
t = linspace(0,5);
lsim(H,sin(w*t),t); grid on
%% Simulate the response to a sinewave with the frequency w 10 times smaller than wc (low frequency zone)
w = wc/10;
lsim(H,sin(w*t),t); grid on
%% Simulate the response to a sinewave with the frequency w 100 times bigger than wc (high frequency zone)
w = wc*4e5; Tu = 2*pi/w;
t = 0:Tu/10:Tu;
lsim(H,sin(w*t),t); grid on; shg;
title("Response simulation in high frequeny zone")
axis([0,max(t),-0.5*1e-4,0.5*1e-4])
H = tf(2.2,[1e-3,1])
nyquist(H)
%t = linspace(0,Tu,Tu:10)

% facem noi si el de ordin 2