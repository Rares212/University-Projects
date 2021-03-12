clear all
clc

%% b1
wp = 0.3 * pi;
ws = 0.5 * pi;

deltaP = 0.05;
deltaS = 0.05;

filters = ["dreptunghiular", "triunghiular", "blackman", "chebwin", "hamming",...
           "hanning", "kaiser", "tukey", "lanzcos"];

window = "kaiser_low";
M = 16;
wc = 0.4 * pi;

h = getFilter(M, wc / pi, window);
[deltaPr, deltaSr] = maxDeltas(h, wp, ws);
if (deltaPr < deltaP && deltaSr < deltaS)
    valid = 1;
    display("DeltaPr: " + deltaPr + ", DeltaSr: " + deltaSr); 
    display("Filter: " + window + ", wc: " + wc + ", M = " + M);
else
    valid = 0;
    disp("Filtrul nu este valid");
end
freqz(h)


%% b2
wp = 0.3 * pi;
ws = 0.5 * pi;

% Am facut abaterile si mai mici pentru a obtine un filtru mai bun
deltaP = 0.05;
deltaS = 0.05;

filters = ["dreptunghiular", "triunghiular", "blackman", "chebwin", "hamming",...
           "hanning", "kaiser", "tukey", "lanzcos"];
valid = 0;


for MCurrent = 8 : 8 : 128
    for filterIndex = 1 : length(filters)
        for wcCurrent = linspace(wp, ws, 9)
            
            filter = filters(filterIndex);
            h = getFilter(MCurrent, wcCurrent / pi, filter);
            [deltaPr, deltaSr] = maxDeltas(h, wp, ws);
            if (deltaPr < deltaP && deltaSr < deltaS)
                valid = 1;
                display("DeltaPr: " + deltaPr + ", DeltaSr: " + deltaSr); 
                display("Filter: " + filter + ", wc: " + wcCurrent + ", M = " + MCurrent);
                break;
            end
        end
        if (valid)
            break
        end
    end
    if (valid)
        break
    end
end

%   Pentru abaterile cerute:
%   "DeltaPr: 0.040622, DeltaSr: 0.041364"
%   "Filter: hanning, wc: 1.2566, M = 24"
%   Se poate mai bine, dar asta in faza 4

%   Pentru abateri si mai mici:
%   "DeltaPr: 4.253e-06, DeltaSr: 2.0651e-06"
%   "Filter: chebwin, wc: 1.2566, M = 80"
