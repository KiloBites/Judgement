﻿using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using JetBrains.Annotations;
using KModkit;
using UnityEngine.XR.WSA.Input;
using Rnd = UnityEngine.Random;

partial class Judgement
{
    private int NameLength;
    private bool IsInnocent = true;
    private int Strikes;
    void CrimeCalc()
    {
        Log("CrimeCalc check");
        switch (ChosenCrime)
        {
            case 0:
                IsInnocent = NameSum > 150;
                Log("Press " + (NameSum > 150 ? "INNOCENT" : "GUILTY"));
                break;

            case 1:
                IsInnocent = ForenameValue > SurnameValue;
                Log("Press " + (ForenameValue > SurnameValue ? "INNOCENT" : "GUILTY"));
                break;

            case 2:
                IsInnocent = SurnameValue > ForenameValue;
                Log("Press " + (ForenameValue < SurnameValue ? "INNOCENT" : "GUILTY"));
                break;

            case 3:
                IsInnocent = StrikeChange;
                Log("Number of Strikes has " + (StrikeChange ? "changed, this means you should press GUILTY" : "not changed, this means you should press INNOCENT"));
                break;

            case 4:
                IsInnocent = SolvedModules > UnsolvedModules;
                Log("The number of solved modules is " + SolvedModules + ". Press " + (IsInnocent ? "INNOCENT" : "GUILTY"));
                break;

            case 5:

                IsInnocent = 115 < (NameSum - Forenames[ChosenForename].Length - Surnames[ChosenSurname].Length);
                Log("The sum of letters, subtract the length of the name is " + (NameSum - Forenames[ChosenForename].Length - Surnames[ChosenSurname].Length) + ". Press " + (IsInnocent ? "INNOCENT" : "GUILTY"));
                break;

            case 6:

                IsInnocent = 750 < (Bomb.GetPortCount() * NameSum);

                break;

            case 7:
                
                string o = NameSum.ToString();
                
                IsInnocent = o.Any(x => "97531".Contains(x));
                break;

            case 8:
                string e = NameSum.ToString();
                IsInnocent = e.Any(x => "08642".Contains(x));
                break;

            case 9:
                IsInnocent = 147 > NameSum;
                Log(IsInnocent ? "The sum of all letters in the name is less than the sum of letters in MINOR LARCENY. Press INNOCENT" : "The sum of all letters in the name is more than the sum of letters in MINOR LARCENY. Press GUILTY.");
                break;

            case 10:
                IsInnocent = (NameSum * 11) > 1000;
                Log(IsInnocent ? "Letters multiplied by 11 is more than 1000. Press INNOCENT" : "Letters multiplied by 11 is less than 1000. Press GUILTY");
                break;

            case 11:
                
                break;

            case 12:

                break;

            case 13:

                break;

            case 14:

                break;

            case 15:

                break;
            case 16:

                break;
            case 17:

                break;
            case 18:

                break;
            case 19:

                break;
            case 20:

                break;
            case 21:

                break;
            case 22:
                IsInnocent = Rnd.Range(0, 2) == 0;
                if (IsInnocent)
                {
                    Audio.PlaySoundAtTransform("teleportingbread", transform);
                    Log("The sound has played, press INNOCENT.");
                }
                else
                {
                    Log("The sound did not play, press GUILTY");
                }
                break;
            case 23:

                break;
            case 24:

                break;
            case 25:

                break;
            case 26:

                break;
            case 27:

                break;
            case 28:

                break;
            case 29:

                break;
            case 30:

                break;
            case 31:

                break;
            case 32:

                break;

        }
    }
void ChangeStrikes(int Strikes)
    {
        if (Strikes != Bomb.GetStrikes())
        {
            StrikeChange = true;
        }
    }

}