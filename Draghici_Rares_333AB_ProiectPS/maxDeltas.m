function [deltaPr, deltaSr] = maxDeltas(h, wp, ws)
    % Functia returneaza abaterile maxime deltaPr si deltaSr
    % in benzile de trecere si stopare ale unui FTJ
    % Argumente: wp: frecventa banda trecere
    %            ws: frecventa banda stopare
    % Iesiri: deltaPr - abaterea in banda de trecere
    %         deltaSr - abaterea in banda de stopare
    omegaPass = linspace(0, wp, 1000);
    H = freqz(h, 1, omegaPass);
    deltaPr = max(abs(1 - abs(H)));
    
    omegaStop = linspace(ws, pi, 1000);
    H = freqz(h, 1, omegaStop);
    deltaSr = max(abs(H));
end

