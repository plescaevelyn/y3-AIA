function [] = cm(MdB)
    M = 10^(MdB/20); % modulul

    radius = M/(M^2-1);
    cx = -M^2/(M^2-1);
    x = 0:pi/180:2*pi;
    sdf = roots([-4 0 4 0 -1/M^2])
    df = sdf(4); % factorul de amortizare apare sub 0.7
    overshoot = round(exp(-M*pi*2*df^2)*100)

    plot(radius*sin(x)+cx, radius*cos(x),'r'); grid;
    text(cx,radius,[num2str(MdB),'dB,\sigma=',num2str(overshoot)],'Color','m')
end