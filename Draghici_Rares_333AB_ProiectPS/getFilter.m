function [h] = getFilter(M, wc, windowType)
    % Proiecteaza un filtru
    % Argumente: M - Ordinul filtrului
    %            wc - frecventa de taiere
    %            windowType - string, reprezinta tipul ferestrei
    % Iesiri: h - filtrul
    switch windowType
        case "dreptunghiular"
            w = boxcar(M);
        case "triunghiular"
            w = triang(M);
        case "blackman"
            w = blackman(M);
        case "chebwin_low"
            w = chebwin(M, 80);
        case "chebwin"
            w = chebwin(M, 90);
        case "chebwin_high"
            w = chebwin(M, 100);
        case "hamming"
            w = hamming(M);
        case "hanning"
            w = hanning(M);
        case "kaiser_low"
            w = kaiser(M, 2);
        case "kaiser"
            w = kaiser(M, 4);
        case "kaiser_high"
            w = kaiser(M, 8);
        case "tukey_low"
            w = tukeywin(M, 0.1);
        case "tukey"
            w = tukeywin(M, 0.5);
        case "tukey_high"
            w = tukeywin(M, 0.9);
        case "lanzcos_low"
            w = lanzcos(M, 0.5);
        case "lanzcos"
            w = lanzcos(M, 1);
        case "lanzcos_high"
            w = lanzcos(M, 1.5);
    end
    w = w / sum(w);
    h = fir1(M-1, wc, 'low', w);
end

