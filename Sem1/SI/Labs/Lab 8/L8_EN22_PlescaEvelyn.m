clear variables; clc;

s = load("lab8_3.mat");

figure,
subplot(211); plot(s.id); title("Identification data");
subplot(212); plot(s.val); title("Validation data");
%% Initializing values
alpha = 0.2; % stepsize
delta = 1e-3; % threshold
l = 0; % iteration counter
lmax = 100; % max iterations, 100-250 iteration range
b = 1;
f = 1;

threshold_reached = 0; % checking if abs(theta_l-theta_{l-1} < delta

% prealocating variable values (for speed)
epsilon = zeros(length(s.id.OutputData));
dedf = zeros(length(s.id.OutputData));
dedb = zeros(length(s.id.OutputData));
dedt = cell(1,length(s.id.OutputData));
% thetarecurs = cell(1,length(s.id.OutputData));
%% Computing recursion formulas
while l <= lmax || threshold_reached == 0
    % initializing theta
    if (l > 0)
        theta_recurs = theta{1,length(theta)};
    else 
        theta_recurs = [1;1];
    end 

    % initializing the recursive elements
    epsilon(1) = s.id.OutputData(1);
    f = theta_recurs(1);
    b = theta_recurs(2);
    dedf(1) = 0;
    dedb(1) = 0;
    % dedt{1} = 0;
    gradient = 0; % gradient of the function
    h = 0; % hessian function

    for k = 2:length(s.id.OutputData)
        epsilon(k) = -f*epsilon(k-1)+s.id.OutputData(k)+f*s.id.OutputData(k-1)-b*s.id.InputData(k-1); % prediction error
        dedf(k) = -epsilon(k-1)-f*dedf(k-1)+s.id.OutputData(k-1);
        dedb(k) = -f*dedb(k-1)-s.id.InputData(k-1);
        dedt{k} = [dedf(k);dedb(k)];
        gradient = gradient + 2/length(s.id.InputData)*dedt{1,k}*epsilon(k); % gradient of the objective function
        h = h + 2/length(s.id.InputData)*dedt{1,k}*dedt{1,k}'; % hessian of the function
    end

    if l > 0
        theta{1,l} = theta{1,l-1}-alpha*inv(h)*gradient;
    else 
        theta{1,1} = [1;1]-alpha*inv(h)*gradient;
        l = l+1;
    end

    if l > 1 & abs(theta{1,l}-theta{1,l-1}) <= delta
        threshold_reached = 1;
    end
    l = l+1;
end

% parameters needed for idpoly function
theta = theta{1,length(theta)};
f = theta(1);
b = theta(2);
A = 1;
B = [0 b];
C = 1;
D = 1;
F = [1 f];

% creating the OE model
model = idpoly(A,B,C,D,F,0,s.id.Ts);

figure,
compare(s.val,model); 