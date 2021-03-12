function [h, deltaPr, deltaSr] = findFilterNonstandard(wp, ws, deltaP, deltaS)
    % Functia incearca sa caute un filtru optim in functie de cerintele de
    % proiectare, incercand sa minimizeze ordinul filtrului
    % Argumente: wc - frecventa de trecere
    %            deltaP - abaterea maxima in banda de trecere
    %            deltaS - abaterea maxima in banda de stopare
    % Iesiri: h - filtrul proiectat
    %         deltaPr - abaterea in banda de trecere
    %         deltaSr - abaterea in banda de stopare
    
    % O lista cu ferestrele folosite in cautare
    % ordonate aproximativ in ordinea utilitatii lor pentru
    % a optimiza cautarea
    filters = ["blackman", "chebwin", "chebwin_low", "chebwin_high", "hamming",...
               "hanning", "kaiser", "kaiser_low", "kaiser_high", "tukey", ... 
               "tukey_low", "tukey_high", "lanzcos", "lanzcos_low", "lanzcos_high",...
               "triunghiular", "dreptunghiular"];
           
    % O incercare de a optimiza cautarea dand pondere mai mare valorilor
    % de mijloc ale wc
    %mid = (ws + wp) / 2;
    %left = flip(logspace(log10(mid), log10(wp), 25));
    %right = logspace(log10(mid), log10(ws), 25);
    %wcSearch = [left right(2:end)];
    
    % O cautare brute-force a filtrului cu M minim
    for MCurrent = 2 : 2 : 256
        for filterIndex = 1 : length(filters)
            
            % In toate situatiile de test incercate, wc optim a fost
            % intotdeauna foarte apropriat de valoarea de mijloc dintre wp
            % si ws, deci pentru a optimiza cautarea am omis incercarea de
            % a cauta si alte valori ale lui wc
            
            for wcCurrent = linspace(wp, ws, 9)
            %for wcCurrent = (ws + wp) / 2
            %for wcIndex = 1 : length(wcSearch)
                % Pentru unele valori ale lui M si ale ferestrei, functia fir1 nu poate
                % returna un filtru. Astfel, am pus cautarea intr-un bloc
                % try catch pentru a putea ignora valorile ale lui M care
                % nu returneaza un filtru
                try
                    M = MCurrent;
                    filter = filters(filterIndex);                   
                    K = (MCurrent - 1) / 2;
                    m = 0 : MCurrent - 1;
                    h_id = sin(wcCurrent .* (m - K)) ./ (pi * (m - K));
                    h_id = h_id';
                    
                    switch filter
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
                    h = h_id .* w;
                    h = h / sum(h);
                    [deltaPr, deltaSr] = maxDeltas(h, wp, ws);
                    if (deltaPr < deltaP && deltaSr < deltaS)
                        disp("Filtrul a fost gasit:");
                        display("DeltaPr: " + deltaPr + ", DeltaSr: " + deltaSr); 
                        display("Window: " + filter + ", wc: " + wcCurrent / pi + "pi, M = " + MCurrent);
                        return
                    end
                catch
                    continue
                end
            end
        end
    end
    disp("Nu a fost gasit un filtru care sa indeplineasca criteriile");
end

