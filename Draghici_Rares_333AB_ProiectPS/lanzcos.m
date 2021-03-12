function [w] = lanzcos(M, L)
% Returneaza fereastra Lanzcos
% Intrari: M - Lungimea ferestrei
%          L - Deschiderea ferestrei, L > 0
% Iesiri: w - fereastra Lanzcos
    m = 0 : M-1;
    a = (2 * m - M + 1) / (2 * (M - 1));
    w = (sin((2 * pi) .* a) ./ ((2 * pi) .* a)) .^ L;
end

