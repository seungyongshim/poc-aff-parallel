using LanguageExt;
using LanguageExt.Sys.Live;
using static LanguageExt.Prelude;

var q = (Job1Aff(), Job2Aff()).Sequence();

var rt = Runtime.New();

await q.Run(rt).ConfigureAwait(false);


Aff<Runtime, Unit> Job1Aff() => Eff<Runtime, Unit>(rt =>
{
    Console.WriteLine($"{DateTime.Now} Job1");
    return unit;
}).Repeat(Schedule.Recurs(10) | Schedule.Exponential(1));

Aff<Runtime, Unit> Job2Aff() => Eff<Runtime, Unit>(rt =>
{
    Console.WriteLine($"{DateTime.Now} Job2");
    return unit;
}).Repeat(Schedule.Recurs(10) | Schedule.Exponential(1));
