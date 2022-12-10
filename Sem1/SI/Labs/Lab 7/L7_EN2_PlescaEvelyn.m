clear variables; clc;

s = load('uval.mat');
yval = system_simulator(6,s.u); % validation dataset/output signal

N = 350;
m = 3;
a = 0.5;
b = 1;

uid = prbs(N,m,a,b); % identification input signal
yid = system_simulator(6,uid'); % identification output signal
yhat = arx(yid,[15 15 0]); % arx model for the identification data

figure,
subplot(2,1,1); compare(yhat,yid); title('Identification compare');
subplot(2,1,2); compare(yhat,yval); title('Validation compare');

m = 10;

uid = prbs(N,m,a,b);
yid = system_simulator(6,uid');
yhat = arx(yid,[15 15 0]);

figure,
subplot(2,1,1); compare(yhat,yid); title('Identification compare');
subplot(2,1,2); compare(yhat,yval); title('Validation compare');

function x = prbs(N,m,a,b)
    x = ones(1,N);
    
    for i = m+1:N
        x(i) = mod(x(i-m:i-1)*coefficients(m)',2);
    end

    for i = 1:N
        if x(i) == 1
            x(i) = a;
        else 
            x(i) = b;
        end
    end
end

function A = coefficients(m)
    A = zeros(1,m);
    switch m
        case 3
            A(1) = 1;
            A(3) = 1;
        case 4
            A(1) = 1;
            A(4) = 1;
        case 5
            A(2) = 1;
            A(5) = 1;
        case 6
            A(1) = 1;
            A(6) = 1;
        case 7
            A(1) = 1;
            A(7) = 1;
        case 8
            A(1) = 1;
            A(2) = 1;
            A(7) = 1;
            A(8) = 1;
        case 9
            A(4) = 1;
            A(9) = 1;
        case 10
            A(3) = 1;
            A(10) = 1;
    end
end