clear variables; clc;

s = load('iddata-09.mat'); % loading the data

m = 2; % maximum order of the dynamics, the polynomial degree

na = 2; % configurable, na=nb
nb = 2; % configurable
nk = 1;

if na > 1 && nb > 1
    [allcombinations2,combinations2] = find2combinations(na); % finding all the combinations of na and nb
    allcombinations3 = find3combinations(na); % finding all the combinations of na and nb
end

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
%% Prediction for identification data
switch m
    case 1
        phi_id = zeros(length(s.id.InputData),na+nb);

        for k = 1:length(s.id.InputData) 
            for i = 1:na
                if (k-i > 0)
                    phi_id(k,i) = -1*s.id.OutputData(k-i); % y(k-i)
                end
            end

            for i = na+1:na+nb
                if (k-i > 0)
                    phi_id(k,i) = s.id.InputData(k-i); % u(k-i)
                end
            end
        end

    case 2
        if na == 1 && nb == 1
            phi_id = [ones(length(s.id.InputData),1),zeros(length(s.id.InputData),4*na+1)];
       
            for k = 1:length(s.id.InputData)
                for i = 1:na
                    if (k-i > 0)
                        phi_id(k,i+1) = -1*s.id.OutputData(k-i); % y(k-i)
                    end
                end

                for i = na+1:2*na
                    if (k-i > 0)
                        phi_id(k,i+1) = s.id.InputData(k-i); % u(k-i)
                    end
                end

                if (k > 1)
                    phi_id(k,2*na+1) = s.id.InputData(k-1)*s.id.OutputData(k-1);
                end

                for i = 2*na+2:3*na+1
                    phi_id(k,i+1) = s.id.OutputData(i)^3; % y(k-i)^2
                end

                for i = 3*na+2:4*na+1
                    phi_id(k,i+1) = s.id.InputData(i)^3; % u(k-i)^2
                end
            end
        else
            for k = 1:length(s.id.InputData) 
                for i = 1:na
                    if (k-i > 0)
                        phi_id(k,i+1) = -1*s.id.OutputData(k-i); % y(k-i)
                    end
                end 

                for i = na+1:2*na
                    if (k-i > 0)
                        phi_id(k,i+1) = s.id.InputData(k-i); % u(k-i)
                    end
                end 

                for i = 1:length(combinations2(:,1))
                    if (k>i && k > combinations2(i,1) && k > combinations2(i,2))
                        % combinatiile de tip y(k-i)y(k-j)
                        phi_id(k,i+2*na+1) = s.id.OutputData(k-combinations2(i,1))*s.id.OutputData(k-combinations2(i,2));
                        % combinatiile de tip u(k-i)u(k-j)
                        phi_id(k,i+1+2*na+length(combinations2(:,1))+length(allcombinations2)) = s.id.InputData(k-combinations2(i,1))*s.id.InputData(k-combinations2(i,2));
                    end
                end

                for i = 1:length(allcombinations2(:,1))
                    if (k>i && k > allcombinations2(i,1) && k > allcombinations2(i,2))
                    % combinatiile de tip y(k-i)u(k-j)
                    phi_id(k,i+1+2*na+length(combinations2(:,1))) = s.id.OutputData(k-allcombinations2(i,1))*s.id.InputData(k-allcombinations2(i,2));
                    end
                end

                for i = 1*na+2*length(combinations2)+length(allcombinations2)+1:2*na+2*length(combinations2)+length(allcombinations2)
                    phi_id(k,i+1) = s.id.OutputData(i)^m; % y(k-i)^2
                end

                for i = 2*na+2*length(combinations2)+length(allcombinations2)+1:3*na+2*length(combinations2)+length(allcombinations2)
                    phi_id(k,i+1) = s.id.InputData(i)^m; % u(k-i)^2
                end 
            end
        end

    case 3
        if na == 1 && nb == 1
            phi_id = [ones(length(s.id.InputData),1),zeros(length(s.id.InputData),6*na+4)];

            for k = 1:length(s.id.InputData)
                for i = 1:na
                    if (k-i > 0)
                        phi_id(k,i+1) = -1*s.id.OutputData(k-i); % y(k-i)
                    end
                end

                for i = na+1:2*na
                    if (k-i > 0)
                        phi_id(k,i+1) = s.id.InputData(k-i); % u(k-i)
                    end
                end
                if (k > 1)
                    phi_id(k,2*na+1) = s.id.InputData(k-1)*s.id.OutputData(k-1);
                end

                for i = 2*na+2:3*na+1
                    if (k > i)
                        phi_id(k,i+1) = s.id.OutputData(i)^2; % y(k-i)^2
                    end
                end

                for i = 3*na+2:4*na+1
                    if (k > i)
                        phi_id(k,i+1) = s.id.InputData(i)^2; % u(k-i)^2
                    end
                end
    
                if (k > 1)
                    phi_id(k,4*na+3) = s.id.OutputData(i)*s.id.OutputData(i)*s.id.InputData(i);
                    phi_id(k,4*na+4) = s.id.InputData(i)*s.id.InputData(i)*s.id.OutputData(i);
                end

                for i = 4*na+4:5*na+3
                    if (k > i)
                        phi_id(k,i+1) = s.id.OutputData(i)^3; % y(k-i)^3
                    end
                end

                for i = 5*na+4:6*na+3
                    if (k > i)
                        phi_id(k,i+1) = s.id.InputData(i)^3; % u(k-i)^3
                    end
                end  
            end
        else
            phi_id = [ones(length(s.id.InputData),1),zeros(length(s.id.InputData),4*na+length(allcombinations2(:,1))+2*length(combinations2(:,1)))];  

            for k = 1:length(s.id.InputData)
                for i = 1:na
                    if (k-i > 0)
                        phi_id(k,i+1) = -1*s.id.OutputData(k-i); % y(k-i)
                    end
                end

                for i = na+1:2*na
                    if (k-i > 0)
                        phi_id(k,i+1) = s.id.InputData(k-i); % u(k-i)
                    end
                end

                for i = 1:length(combinations2(:,1))
                    if k>i && k > combinations2(i,1) && k > combinations2(i,2)
                        % combinatiile de tip y(k-i)y(k-j)
                        phi_id(k,i+2*na+1) = s.id.OutputData(k-combinations2(i,1))*s.id.OutputData(k-combinations2(i,2));
                        % combinatiile de tip u(k-i)u(k-j)
                        phi_id(k,i+1+2*na+length(allcombinations2(:,1))+length(allcombinations2(:,1))) = s.id.InputData(k-combinations2(i,1))*s.id.InputData(k-combinations2(i,2));
                    end
                end

                for i = 1:length(allcombinations2(:,1))
                    if (k>i && k > allcombinations2(i,1) && k > allcombinations2(i,2))
                        % combinatiile de tip y(k-i)u(k-j)
                        phi_id(k,i+1+2*na+length(allcombinations2(:,1))) = s.id.OutputData(k-allcombinations2(i,1))*s.id.InputData(k-allcombinations2(i,2));
                    end
                end

                for i = 1*na+2*length(allcombinations2(:,1))+length(allcombinations2(:,1))+1:2*na+2*length(allcombinations2(:,1))+length(allcombinations2(:,1))
                    phi_id(k,i+1) = s.id.OutputData(i)^2; % y(k-i)^2
                end

                for i = 2*na+2*(length(allcombinations2)/2)+length(allcombinations2(:,1))+1:3*na+2*length(allcombinations2(:,1))+length(allcombinations2(:,1))
                    phi_id(k,i+1) = s.id.InputData(i)^2; % u(k-i)^2
                end

                for i = 1:length(allcombinations3(:,1))
                    if (k>i && k > allcombinations3(i,2) && k > allcombinations3(i,1) && k > allcombinations3(i,3) && k > allcombinations3(i,2))
                        % combinatiile de tip y(k-i)y(k-i)u(k-j)
                        phi_id(k,i+3*na+2*length(allcombinations2(:,1))+length(allcombinations2(:,1))) = s.id.OutputData(k-allcombinations3(i,1))*s.id.OutputData(k-allcombinations3(i,2))*s.id.InputData(k-allcombinations3(i,3));
                        % combinatiile de tip y(k-i)u(k-i)u(k-j)
                        phi_id(k,i+3*na+2*length(allcombinations2(:,1))+length(allcombinations2(:,1))+length(allcombinations3(:,1))) = s.id.InputData(k-allcombinations3(i,1))*s.id.InputData(k-allcombinations3(i,2))*s.id.OutputData(k-allcombinations3(i,3));
                    end
                end

                for i = 3*na+2*length(allcombinations2(:,1))+length(allcombinations2)+1:4*na+2*length(allcombinations3(:,1))
                    phi_id(k,i+1) = s.id.OutputData(i)^3; % y(k-i)^3
                end

                for i = 4*na+2*(length(allcombinations2(:,1)))+length(allcombinations2(:,1))+2*length(allcombinations3(:,1))+1:5*na+2*(length(allcombinations2(:,1)))+length(allcombinations2(:,1))+2*length(allcombinations3(:,1))
                    phi_id(k,i+1) = s.id.InputData(i)^3; % u(k-i)^3
                end
            end
        end
end

theta = phi_id\s.id.OutputData;
y_cap = phi_id*theta;

mse_id = 1/length(s.id.OutputData)*sum((y_cap-s.id.OutputData).^2);

figure,
plot(1:length(s.id.OutputData),s.id.OutputData,1:length(s.id.OutputData),y_cap); title('Output for identification data and model, Identification MSE = ',num2str(mean(mse_id)));
xlabel('Time'); ylabel('Output');
%% Prediction for validation data
switch m
    case 1
        phi_val = zeros(length(s.val.InputData),na+nb);

        for k = 1:length(s.val.InputData) 
            for i = 1:na
                if (k-i > 0)
                    phi_val(k,i) = -1*s.val.OutputData(k-i); % y(k-i)
                end
            end

            for i = na+1:na+nb
                if (k-i > 0)
                    phi_val(k,i) = s.val.InputData(k-i); % u(k-i)
                end
            end
        end

    case 2
        if na == 1 && nb == 1
            phi_val = [ones(length(s.val.InputData),1),zeros(length(s.val.InputData),4*na+1)];

            for k = 1:length(s.val.InputData)
                for i = 1:na
                    if (k-i > 0)
                        phi_val(k,i+1) = -1*s.val.OutputData(k-i); % y(k-i)
                    end
                end

                for i = na+1:2*na
                    if (k-i > 0)
                        phi_val(k,i+1) = s.val.InputData(k-i); % u(k-i)
                    end
                end

                if (k > 1)
                    phi_val(k,2*na+1) = s.val.InputData(k-1)*s.val.OutputData(k-1);
                end

                for i = 2*na+2:3*na+1
                    if (k > i)
                        phi_val(k,i+1) = s.val.OutputData(i)^m; % y(k-i)^2
                    end
                end

                for i = 3*na+2:4*na+1
                    if (k > i)
                        phi_val(k,i+1) = s.val.InputData(i)^m; % u(k-i)^2
                    end
                end 
            end
        else
            phi_val = [ones(length(s.val.InputData),1),zeros(length(s.val.InputData),4*na+length(allcombinations2(:,1))+2*length(combinations2(:,1)))];  % aici am initializat vectorul sa aiba prima valoare 1
            
            for k = 1:length(s.val.InputData)
                for i = 1:na
                    if (k-i > 0)
                        phi_val(k,i+1) = -1*s.val.OutputData(k-i); % y(k-i)
                    end
                end

                for i = na+1:2*na
                    if (k-i > 0)
                        phi_val(k,i+1) = s.val.InputData(k-i); % u(k-i)
                    end
                end

                for i = 1:length(combinations2(:,1))
                    if (k>i && k > combinations2(i,1) && k > combinations2(i,2))
                        % combinatiile de tip y(k-i)y(k-j)
                        phi_val(k,i+2*na+1) = s.val.OutputData(k-combinations2(i,1))*s.val.OutputData(k-combinations2(i,2));
                        % combinatiile de tip u(k-i)u(k-j)
                        phi_val(k,i+1+2*na+length(combinations2(:,1))+length(allcombinations2(:,1))) = s.val.InputData(k-combinations2(i,1))*s.val.InputData(k-combinations2(i,2));
                    end
                end

                for i = 1:length(allcombinations2(:,1))
                    if (k>i && k > allcombinations2(i,1) && k > allcombinations2(i,2))
                        % combinatiile de tip y(k-i)u(k-j)
                        phi_val(k,i+1+2*na+length(combinations2(:,1))) = s.val.OutputData(k-allcombinations2(i,1))*s.val.InputData(k-allcombinations2(i,2));
                    end
                end

                for i = 1*na+2*length(combinations2(:,1))+length(allcombinations2(:,1))+1:2*na+2*length(combinations2(:,1))+length(allcombinations2(:,1))
                    phi_val(k,i+1) = s.val.OutputData(i)^m; % y(k-i)^2
                end

                for i = 2*na+2*length(combinations2(:,1))+length(allcombinations2(:,1))+1:3*na+2*length(combinations2(:,1))+length(allcombinations2(:,1))
                    phi_val(k,i+1) = s.val.InputData(i)^m; % u(k-i)^2
                end
            end
        end
    
    case 3
        if na == 1 && nb == 1
            phi_val = [ones(length(s.val.InputData),1),zeros(length(s.val.InputData),6*na+4)];

            for k = 1:length(s.val.InputData)
                for i = 1:na
                    if (k-i > 0)
                        phi_val(k,i+1) = -1*s.val.OutputData(k-i); % y(k-i)
                    end
                end

                for i = na+1:2*na
                    if (k-i > 0)
                        phi_val(k,i+1) = s.val.InputData(k-i); % u(k-i)
                    end
                end

                if (k > 1)
                    phi_val(k,2*na+1) = s.val.InputData(k-1)*s.val.OutputData(k-1);
                end

                for i = 2*na+2:3*na+1
                    if (k > i)
                        phi_val(k,i+1) = s.val.OutputData(i)^2; % y(k-i)^2
                    end
                end

                for i = 3*na+2:4*na+1
                    if (k > i)
                        phi_val(k,i+1) = s.val.InputData(i)^2; % u(k-i)^2
                    end
                end
        
                if (k > 1)
                    phi_val(k,4*na+3) = s.val.OutputData(i)*s.val.OutputData(i)*s.val.InputData(i);
                    phi_val(k,4*na+4) = s.val.InputData(i)*s.val.InputData(i)*s.val.OutputData(i);
                end

                for i = 4*na+4:5*na+3
                    if (k > i)
                        phi_val(k,i+1) = s.val.OutputData(i)^m; % y(k-i)^3
                    end
                end

                for i = 5*na+4:6*na+3
                    if (k > i)
                        phi_val(k,i+1) = s.val.InputData(i)^m; % u(k-i)^3
                    end
                end  
            end
        else
            phi_val = [ones(length(s.val.InputData),1),zeros(length(s.val.InputData),4*na+length(allcombinations2(:,1))+2*length(combinations2(:,1)))];

            for k = 1:length(s.val.InputData)            
                for i = 1:na
                    if (k-i > 0)
                        phi_val(k,i+1) = -1*s.val.OutputData(k-i); % y(k-i)
                    end
                end

                for i = na+1:2*na
                    if (k-i > 0)
                        phi_val(k,i+1) = s.val.InputData(k-i); % u(k-i)
                    end
                end

                for i = 1:length(combinations2(:,1))
                    if (k>i && k > combinations2(i,1) && k > combinations2(i,2))
                        % combinatiile de tip y(k-i)y(k-j)
                        phi_val(k,i+2*na+1) = s.val.OutputData(k-combinations2(i,1))*s.val.OutputData(k-combinations2(i,2));
                        % combinatiile de tip u(k-i)u(k-j)
                        phi_val(k,i+1+2*na+length(combinations2(:,1))+length(allcombinations2(:,1))) = s.val.InputData(k-combinations2(i,1))*s.val.InputData(k-combinations2(i,2));
                    end
                end

                for i = 1:length(allcombinations2(:,1))
                    if (k>i && k > allcombinations2(i,1) && k > allcombinations2(i,2))
                        % combinatiile de tip y(k-i)u(k-j)
                        phi_val(k,i+1+2*na+length(combinations2(:,1))) = s.val.OutputData(k-allcombinations2(i,1))*s.val.InputData(k-allcombinations2(i,2));
                    end
                end

                for i = 1*na+2*length(combinations2(:,1))+length(allcombinations2(:,1))+1:2*na+2*length(combinations2(:,1))+length(allcombinations2(:,1))
                    phi_val(k,i+1) = s.val.OutputData(i)^2; % y(k-i)^2
                end

                for i = 2*na+2*length(combinations2(:,1))+length(allcombinations2(:,1))+1:3*na+2*length(combinations2(:,1))+length(allcombinations2(:,1))
                    phi_val(k,i+1) = s.val.InputData(i)^2; % u(k-i)^2
                end

                for i = 1:length(allcombinations3(:,1))
                    if (k>i && k > allcombinations3(i,2) && k > allcombinations3(i,1) && k > allcombinations3(i,3) && k > allcombinations3(i,2))
                        % combinatiile de tip y(k-i)y(k-i)u(k-j)
                        phi_val(k,i+3*na+2*length(allcombinations2(:,1))+length(allcombinations2(:,1))) = s.val.OutputData(k-allcombinations3(i,1))*s.val.OutputData(k-allcombinations3(i,2))*s.val.InputData(k-allcombinations3(i,3));
                        % combinatiile de tip y(k-i)u(k-i)u(k-j)
                        phi_val(k,i+3*na+2*length(allcombinations2(:,1))+length(allcombinations2(:,1))+1) = s.val.InputData(k-allcombinations3(i,1))*s.val.InputData(k-allcombinations3(i,2))*s.val.OutputData(k-allcombinations3(i,3));
                    end
                end

                for i = 3*na+2*length(allcombinations2(:,1))+length(allcombinations2(:,1))+1:4*na+2*length(allcombinations3(:,1))
                    phi_val(k,i+1) = s.val.OutputData(i)^m; % y(k-i)^3
                end

                for i = 4*na+2*(length(allcombinations2(:,1)))+length(allcombinations2(:,1))+2*length(allcombinations3(:,1))+1:5*na+2*(length(allcombinations2(:,1)))+length(allcombinations2(:,1))+2*length(allcombinations3(:,1))
                    phi_val(k,i+1) = s.val.InputData(i)^m; % u(k-i)^3
                end
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

switch m
    case 1
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

    case 2
        if na == 1 && nb == 1
            phi = [ones(length(s.val.InputData),1),zeros(length(s.val.InputData),4*na+1)];

            for k = 2:length(s.val.InputData)
                for i = 1:na
                    if (k-i > 0)
                        phi(k,i+1) = -1*ysim(k-i); % y(k-i)
                    end
                end

                for i = na+1:2*na
                    if (k-i > 0)
                        phi(k,i+1) = s.val.InputData(k-i); % u(k-i)
                    end
                end

                if (k > 1)
                    phi_val(k,2*na+1) = s.val.InputData(k-1)*ysim(k-1)*ysim(k-1);
                    phi_val(k,2*na+2) = s.val.InputData(k-1)*s.val.OutputData(k-1)*ysim(k-1);
                end

                for i = 2*na+3:3*na+2
                    phi_val(k,i+1) = ysim(i)^2; % y(k-i)^2
                end

                for i = 3*na+3:4*na+2
                    phi_val(k,i+1) = s.val.InputData(i)^2; % u(k-i)^2
                end
            end
        else
            phi = [ones(length(s.val.InputData),1),zeros(length(s.val.InputData),4*na+length(allcombinations2(:,1))+2*length(combinations2(:,1)))];

            for k = 2:length(s.val.InputData)
                for i = 1:na
                    if (k-i > 0)
                        phi(k,i+1) = -1*ysim(k-i); % y(k-i)
                    end
                end

                for i = na+1:2*na
                    if (k-i > 0)
                        phi(k,i+1) = s.val.InputData(k-i); % u(k-i)
                    end
                end

                for i = 1:length(combinations2(:,1))
                    if (k>i && k > combinations2(i,1) && k > combinations2(i,2))
                        % combinatiile de tip y(k-i)y(k-j)
                        phi(k,i+2*na+1) = ysim(k-combinations2(i,1))*ysim(k-combinations2(i,2));
                        % combinatiile de tip u(k-i)u(k-j)
                        phi(k,i+1+2*na+length(combinations2(:,1))+length(allcombinations2(:,1))) = s.val.InputData(k-combinations2(i,1))*s.val.InputData(k-combinations2(i,2));
                    end
                end

                for i = 1:length(allcombinations2(:,1))
                    if (k>i && k > allcombinations2(i,1) && k > allcombinations2(i,2))
                        % combinatiile de tip y(k-i)u(k-j)
                        phi(k,i+1+2*na+length(combinations2(:,1))) = ysim(k-allcombinations2(i,1))*s.val.InputData(k-allcombinations2(i,2));
                    end
                end

                for i = na+2*length(combinations2(:,1))+length(allcombinations2(:,1))+1:2*na+2*length(combinations2(:,1))+length(allcombinations2(:,1))
                    phi(k,i+1) = ysim(i)^m; % y(k-i)^2
                end

                for i = 2*na+2*length(combinations2)+length(allcombinations2(:,1))+1:3*na+2*length(combinations2(:,1))+length(allcombinations2(:,1))
                    phi(k,i+1) = s.val.InputData(i)^m; % u(k-i)^2
                end
            end

            ysim(i) = phi(i,:)*theta;
        end

    case 3
        if na == 1 && nb == 1
            phi = [ones(length(s.val.InputData),1),zeros(length(s.val.InputData),6*na+4)];

            for k = 1:length(s.val.InputData)
                for i = 1:na
                    if (k-i > 0)
                        phi(k,i+1) = -1*ysim(k-i); % y(k-i)
                    end
                end

                for i = na+1:2*na
                    if (k-i > 0)
                        phi(k,i+1) = s.val.InputData(k-i); % u(k-i)
                    end
                end

                if (k > 1)
                    phi(k,2*na+1) = s.val.InputData(k-1)*ysim(k-1);
                end

                for i = 2*na+2:3*na+1
                    if (k > i)
                        phi(k,i+1) = ysim(i)^2; % y(k-i)^2
                    end
                end

                for i = 3*na+2:4*na+1
                    if (k > i)
                        phi(k,i+1) = s.val.InputData(i)^2; % u(k-i)^2
                    end
                end
    
                if (k > 1)
                    phi(k,4*na+3) = ysim(i)*ysim(i)*s.val.InputData(i);
                    phi(k,4*na+4) = s.val.InputData(i)*s.val.InputData(i)*ysim(i);
                end

                for i = 4*na+4:5*na+3
                    if (k > i)
                        phi(k,i+1) = ysim(i)^m; % y(k-i)^3
                    end
                end

                for i = 5*na+4:6*na+3
                    if (k > i)
                        phi(k,i+1) = s.val.InputData(i)^m; % u(k-i)^3
                    end
                end  

                ysim(i) = phi(i,:)*theta;
            end
        else
            phi = [ones(length(s.val.InputData),1),zeros(length(s.val.InputData),4*na+length(allcombinations2(:,1))+2*length(combinations2(:,1)))];  % aici am initializat vectorul sa aiba prima valoare 1

            for k = 1:length(s.val.InputData)
                for i = 1:na
                    if (k-i > 0)
                        phi(k,i+1) = -1*ysim(k-i); % y(k-i)
                    end
                end

                for i = na+1:2*na
                    if (k-i > 0)
                        phi(k,i+1) = s.val.InputData(k-i); % u(k-i)
                    end
                end

                for i = 1:length(combinations2(:,1))
                    if k>i && k > combinations2(i,1) && k > combinations2(i,2)
                        % combinatiile de tip y(k-i)y(k-j)
                        phi(k,i+2*na+1) = ysim(k-combinations2(i,1))*ysim(k-combinations2(i,2));
                        % combinatiile de tip u(k-i)u(k-j)
                        phi(k,i+1+2*na+length(allcombinations2(:,1))+length(allcombinations2(:,1))) = s.val.InputData(k-combinations2(i,1))*s.val.InputData(k-combinations2(i,2));
                    end
                end

                for i = 1:length(allcombinations2(:,1))
                    if (k>i && k > allcombinations2(i,1) && k > allcombinations2(i,2))
                        % combinatiile de tip y(k-i)u(k-j)
                        phi(k,i+1+2*na+length(allcombinations2(:,1))) = ysim(k-allcombinations2(i,1))*s.val.InputData(k-allcombinations2(i,2));
                    end
                end

                for i = 1*na+2*length(allcombinations2(:,1))+length(allcombinations2(:,1))+1:2*na+2*length(allcombinations2(:,1))+length(allcombinations2(:,1))
                    phi(k,i+1) = ysim(i)^2; % y(k-i)^2
                end

                for i = 2*na+2*(length(allcombinations2(:,1)))+length(allcombinations2(:,1))+1:3*na+2*length(allcombinations2(:,1))+length(allcombinations2(:,1))
                    phi(k,i+1) = s.val.InputData(i)^2; % u(k-i)^2
                end

                for i = 1:length(allcombinations3(:,1))
                    if (k>i && k > allcombinations3(i,2) && k > allcombinations3(i,1) && k > allcombinations3(i,3) && k > allcombinations3(i,2))
                        % combinatiile de tip y(k-i)y(k-i)u(k-j)
                        phi(k,i+3*na+2*length(allcombinations2(:,1))+length(allcombinations2(:,1))) = ysim(k-allcombinations3(i,1))*ysim(k-allcombinations3(i,2))*s.val.InputData(k-allcombinations3(i,3));
                        % combinatiile de tip y(k-i)u(k-i)u(k-j)
                        phi(k,i+3*na+2*length(allcombinations2(:,1))+length(allcombinations2(:,1))+1) = s.val.InputData(k-allcombinations3(i,1))*s.val.InputData(k-allcombinations3(i,2))*ysim(k-allcombinations3(i,3));
                    end
                end

                for i = 3*na+2*length(allcombinations2(:,1))+length(allcombinations2(:,1))+1:4*na+2*length(allcombinations3(:,1))
                    phi(k,i+1) = ysim(i)^m; % y(k-i)^3
                end

                for i = 4*na+2*(length(allcombinations2(:,1)))+length(allcombinations2(:,1))+2*length(allcombinations3(:,1))+1:5*na+2*(length(allcombinations2(:,1)))+length(allcombinations2(:,1))+2*length(allcombinations3(:,1))
                    phi(k,i+1) = s.val.InputData(i)^m; % u(k-i)^3
                end

                ysim(i) = phi(i,:)*theta;
            end
        end
end

theta = phi\s.val.OutputData;
yhatsim = phi*theta;

mse_pred = 1/length(s.val.InputData)*sum((s.val.InputData-ysim).^2);

figure,
plot(1:length(s.val.InputData),s.val.InputData,1:length(s.val.InputData),yhatsim); title('Output for prediction data and model, Validation MSE = ',num2str(mean(mse_pred)));
xlabel('Time'); ylabel('Output');
%% Defining the functions used to retrieve the combinations

% find2combinations retrieves all the possible combinations of na and nb
% used in the case of m=2
function [result, final_result] = find2combinations(na)
    result = []; % includes all combinations that do not repeat themselves
    final_result = []; % includes all combinations that do not repeat themselves and do not contain equal numbers

    for a = 1:na
        for b = a:na
            result = [result;a,b];
        end
    end
    
    for i = 1:length(result)
        if result(i,2) > result(i,1)
            final_result = [final_result;result(i,1),result(i,2)];
        end
    end
end

% find3combinations retrieves all the possible combinations of na and nb
% used in the case m=3
function result = find3combinations(na)
result = []; % includes all combinations that do not repeat themselves
    final_result = []; % includes all combinations that do not repeat themselves and do not contain equal numbers

    for a = 1:na
        for b = 1:na
            for c = 1:na
                result = [result;a,b,c];
            end
        end
    end
end
