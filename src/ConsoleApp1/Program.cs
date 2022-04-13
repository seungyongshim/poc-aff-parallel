using LanguageExt;
using Microsoft.Extensions.Hosting;
using static LanguageExt.Prelude;

var q = (Job1Aff(), Job2Aff()).Sequence();
await q.Run();

Aff<Unit> Job1Aff() => Eff(() =>
{
    Console.WriteLine($"{DateTime.Now} Job1");
    return unit;
}).ToAsync().Repeat(Schedule.Recurs(10) | Schedule.Exponential(1));

Aff<Unit> Job2Aff() => Eff(() =>
{
    Console.WriteLine($"{DateTime.Now} Job2");
    return unit;
}).ToAsync().Repeat(Schedule.Recurs(10) | Schedule.Exponential(1));
