clear variables; clc;

%   WORKING FOR M=1

% unproper combinations for m=3

s = load('iddata-09.mat'); % loading the data

m = 1; % maximum order of the dynamics, the polynomial degree

na = 5; % configurable, na=nb
nb = 5; % configurable 
nk = 1;

figure,
subplot(2,1,1); plot(s.id);
title('Identification data');
subplot(2,1,2); plot(s.val);
title('Validation data');
%% Solving the problem using nlarx function
% Identification data
figure,
id_z = iddata(s.id.OutputData,s.id.InputData,s.id.Ts);
ycap = nlarx(id_z,[na nb nk]); % estimating the nonlinear arx model 
subplot(2,1,1); compare(ycap,id_z);
title('Nonlinear ARX model on identification data calculated using nlarx');

% Validation data
val_z = iddata(s.val.OutputData,s.val.InputData,s.val.Ts);
ycap = nlarx(val_z,[na nb nk]); % estimating the nonlinear arx model
subplot(2,1,2); compare(ycap,val_z);
title('Nonlinear ARX model on validation data calculated using nlarx');
%% Prediction
% Identification data
if m == 1 
    phi_id = zeros(length(s.id.InputData),na+nb);

    for k = 1:length(s.id.InputData) % de verificat daca nu trebuie cumva altfel pus asta ca sa fie ok k
        for i = 1:na
            if (k-i > 0)
                phi_id(k,i) = -1*s.id.OutputData(k-i); % y(k-i)^mm
            end
        end 

        for i = na+1:na+nb
            if (k-i > 0)
                phi_id(k,i) = s.id.InputData(k-i); % u(k-i)^mm
            end
        end 
    end
else
    phi_id = [ones(length(s.id.InputData),1),zeros(length(s.id.InputData),6*na)];  % aici am initializat vectorul sa aiba prima valoare 1  

    for k = 1:length(s.id.InputData) 
        for mm = 1:m-1
            for i = 1:na
                if (k-i > 0)
                    phi_id(k,i+1) = -1*s.id.OutputData(k-i)^mm; % y(k-i)^mm
                end
            end 

            for i = na+1:2*na
                if (k-i > 0)
                    phi_id(k,i+1) = s.id.InputData(k-i)^mm; % u(k-i)^mm
                end
            end 

            combinations_nr = 2^(na-1)-2;
            for i = 1:combinations_nr-1
                % combinatiile de tip y(k-i)y(k-j)
                for j = i+1:na 
                    if (k-i > 0 && k-j > 0)
                        phi_id(k,i+2*na+1) = s.id.OutputData(k-i)*s.id.OutputData(k-j);
                    end
                end

                % combinatiile de tip y(k-i)u(k-j)
                for j = i+1:na % if na!=nb we need to use nb, but in our case they are equal
                    if (k-i > 0 && k-j > 0)
                        phi_id(k,i+3*na+1) = s.id.OutputData(k-i)*s.id.InputData(k-j);
                    end
                end

                % combinatiile de tip u(k-i)u(k-j)
                for j = i+1:na % if na!=nb we need to use nb for both j and k, but in our case they are equal
                    if (k-i > 0 && k-j > 0)
                        phi_id(k,i+4*na+1) = s.id.InputData(k-i)*s.id.InputData(k-j);
                    end
                end
            end
        end 

        for i = 4*na+1:5*na
            phi_id(k,i+1) = s.id.OutputData(i)^m; % y(k-i)^m (valoarea maxima)
        end

        for i = 5*na+1:6*na
            phi_id(k,i+1) = s.id.InputData(i)^m; % u(k-i)^m
        end 
    end
end

theta = phi_id\s.id.OutputData;
y_cap = phi_id*theta;

mse_id = 1/length(s.id.OutputData)*sum((y_cap-s.id.OutputData).^2);

figure, 
plot(1:length(s.id.OutputData),s.id.OutputData,1:length(s.id.OutputData),y_cap); title('Output for identification data and model, Identification MSE = ',num2str(mean(mse_id)));
xlabel('Time'); ylabel('Output');

% Validation data 
if m == 1 
    phi_val = zeros(length(s.val.InputData),na+nb);

    for k = 1:length(s.val.InputData) % de verificat daca nu trebuie cumva altfel pus asta ca sa fie ok k
        for i = 1:na
            if (k-i > 0)
                phi_val(k,i) = -1*s.val.OutputData(k-i); % y(k-i)^mm
            end
        end 

        for i = na+1:na+nb
            if (k-i > 0)
                phi_val(k,i) = s.val.InputData(k-i); % u(k-i)^mm
            end
        end 
    end
else
    phi_val = [ones(length(s.val.InputData),1),zeros(length(s.val.InputData),6*na)];  % aici am initializat vectorul sa aiba prima valoare 1  

    for k = 1:length(s.val.InputData) 
        for mm = 1:m-1
            for i = 1:na
                if (k-i > 0)
                    phi_val(k,i+1) = -1*s.val.OutputData(k-i)^mm; % y(k-i)^mm
                end
            end 

            for i = na+1:2*na
                if (k-i > 0)
                    phi_val(k,i+1) = s.val.InputData(k-i)^mm; % u(k-i)^mm
                end
            end 

            combinations_nr = 2^(na-1)-2;
            for i = 1:combinations_nr-1
                % combinatiile de tip y(k-i)y(k-j)
                for j = i+1:na 
                    if (k-i > 0 && k-j > 0)
                        phi_val(k,i+2*na+1) = s.val.OutputData(k-i)*s.val.OutputData(k-j);
                    end
                end

                % combinatiile de tip y(k-i)u(k-j)
                for j = i+1:na % if na!=nb we need to use nb, but in our case they are equal
                    if (k-i > 0 && k-j > 0)
                        phi_val(k,i+3*na+1) = s.val.OutputData(k-i)*s.val.InputData(k-j);
                    end
                end

                % combinatiile de tip u(k-i)u(k-j)
                for j = i+1:na % if na!=nb we need to use nb for both j and k, but in our case they are equal
                    if (k-i > 0 && k-j > 0)
                        phi_val(k,i+4*na+1) = s.val.InputData(k-i)*s.val.InputData(k-j);
                    end
                end
            end
        end 

        for i = 3*na+1:4*na
            phi_val(k,i+1) = s.val.OutputData(i)^m; % y(k-i)^m (valoarea maxima)
        end

        for i = 4*na+1:5*na
            phi_val(k,i+1) = s.val.InputData(i)^m; % u(k-i)^m
        end 
    end
end

y_val_cap = phi_val*theta;

mse_val = 1/length(s.val.OutputData)*sum((y_val_cap-s.val.OutputData).^2);

figure, 
plot(1:length(s.val.OutputData),s.val.OutputData,1:length(s.val.OutputData),y_val_cap); title('Output for validation data and model, Validation MSE = ',num2str(mean(mse_val)));
xlabel('Time'); ylabel('Output');
%% Simulation
ysim = zeros(length(s.val.InputData),1);

% in loc de forurile alea nu e ok (in interiorul lor), trebuie sa
% gasim combinatiile, e ok ca folosim output data si in loc de y
% punem y simulat

% nu merge, se populeaza doar cu 0 tot (inclusiv phi)

if m == 1
    phi = zeros(length(s.val.InputData),na+nb);
    for i = 2:length(s.val.InputData)
        for j = 1:na
            if (i-j>0)
                phi(i,j) = -1*ysim(i-j);
            end
        end
        for k = na+1:na+nb
            if (na+i-k>0)
                phi(i,k) = s.val.InputData(na+i-k);
            end
        end
        ysim(i) = phi(i,:)*theta;
    end
else
    phi = [ones(length(s.val.InputData),1),zeros(length(s.val.InputData),6*na)];

    for k = 2:length(s.val.InputData) 
        for mm = 1:m-1
            for i = 1:na
                if (k-i > 0)
                    phi_val(k,i+1) = -1*ysim(k-i)^mm; % y(k-i)^mm
                end
            end 
    
            for i = na+1:2*na
                if (k-i > 0)
                    phi_val(k,i+1) = s.val.InputData(k-i)^mm; % u(k-i)^mm
                end
            end 

            for i = 1:na-1
                % combinatiile de tip y(k-i)y(k-j)
                for j = i+1:na 
                    if (k-i > 0 && k-j > 0)
                        phi_val(k,i+2*na+1) = ysim(k-i)*ysim(k-j);
                    end
                end

                % combinatiile de tip y(k-i)u(k-j)
                for j = i+1:na % if na!=nb we need to use nb, but in our case they are equal
                    if (k-i > 0 && k-j > 0)
                        phi_val(k,i+3*na+1) = ysim(k-i)*s.id.InputData(k-j);
                    end
                end

                % combinatiile de tip u(k-i)u(k-j)
                for j = i+1:na % if na!=nb we need to use nb for both j and k, but in our case they are equal
                    if (k-i > 0 && k-j > 0)
                        phi_val(k,i+4*na+1) = s.id.InputData(k-i)*s.id.InputData(k-j);
                    end
                end
            end
        end 

        for i = 3*na+1:4*na
            phi_val(k,i+1) = ysim(i)^m; % y(k-i)^m (valoarea maxima)
        end

        for i = 4*na+1:5*na
            phi_val(k,i+1) = s.val.InputData(i)^m; % u(k-i)^m
        end
    end

    ysim(i) = phi(i,:)*theta;
end

theta = phi\s.val.OutputData;
yhatsim = phi*theta;

mse_pred = 1/length(s.val.InputData)*sum((s.val.InputData-ysim).^2);

figure, 
plot(1:length(s.val.InputData),s.val.InputData,1:length(s.val.InputData),yhatsim); title('Output for prediction data and model, Validation MSE = ',num2str(mean(mse_pred)));
xlabel('Time'); ylabel('Output');

function [result, final_result] = find_combinations(na,nb)
    elements = {1:na 1:nb};  % elements = {1:10' 1:10'};
    combinations = cell(1, numel(elements)); 
    [combinations{:}] = ndgrid(elements{:});
    combinations = cellfun(@(x) x(:), combinations,'uniformoutput',false);
    intermediate_result = [combinations{:}]; 
    intermediate_result = [intermediate_result(:,2),intermediate_result(:,1)];

    result = [];
    final_result = [];

    for i = 1:length(intermediate_result)
        if intermediate_result(i,2) >= intermediate_result(i,1)
            result = [result;intermediate_result(i,1),intermediate_result(i,2)];
        end
    end

    for i = 1:length(intermediate_result)
        if intermediate_result(i,2) > intermediate_result(i,1)
            final_result = [final_result;intermediate_result(i,1),intermediate_result(i,2)];
        end
    end
end