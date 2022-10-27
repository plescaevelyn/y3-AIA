%% lab 4 ex i)
clear variables; clc;

H = tf(20*[1 2],conv([1 5],[1 10]));
zpk(H)

% corner frequency = pulsatie de frangere

%Step 1: bring the terms in the transfer function in their standard form
%Step 2: place in ascending order the corner frequencies and mention the
%contribution of the magnitude after each one: w1 = 2(+20dB), w2 =
%50(-20dB), w3 = 10(-20dB)

w1 = 2;
w2 = 5;
w3 = 10;

%Step 3: establish the range of the frequencies, for getting a sufficient
%representation (graphically obtain de cutting frequency)

w = logspace(-1,2);

% Step 4: compute approximation points (for MAGNITUDE) according to the transfer 
% function structure

% low frequency asymptote, affected only by the proportional gain k
k = 20*2/10/5
m1 = 20*log10(k)
semilogx([min(w),w1],[1 1]*m1,"ro-","LineWidth",2); hold
title('Magnitude characteristic'); xlabel('\omega (lg)');
ylabel('|H(j*\omega|^{dB}'); grid; shg;

m2 = m1 + 20*log10(w2/w1);
m3 = m2 - 20*log(max(w)/w3);

semilogx([w1,w2],[m1,m2],"ro-","LineWidth",2)
semilogx([w2,w3],[m2,m2],"ro-","LineWidth",2)
semilogx([w3,max(w)],[m2,m3],"ro-","LineWidth",2)

%% Verify the approximation 
[m,f] = bode(H,w); semilogx(w,20*log10(squeeze(m)),'b'); shg;