using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Football;

namespace SerializationTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test()
        {
            var dto = new FootballDto
            {
                Filled = DateTime.Now,
                FullName = "Малых Александр Александрович",
                Citizenship = "Русский",
                Age = 19,
                Height = 178,
                Weight = 60,
                AgeStartCareer = 15,
                ExperienceInFootball = 3,
                Position = Position.Goalkeeper,
                WorkingLeg = WorkingLeg.Right,
                WeakSides = WeakSides.Endurance,
                Strengths = Strengths.Reaction,

                Traums = new List<Trauma>()
                {
                new Trauma
                {
                    CountTraums = 0,
                    TimeTraums = 0,
                    TraumаNow = false,
                    Type = TraumaTypes.None
                }
            }
            };
            var tempFileName = Path.GetTempFileName();
            try
            {
                Helper.WriteToFile(tempFileName, dto);
                var readDto = Helper.LoadFromFile(tempFileName);
                Assert.AreEqual(dto.Filled, readDto.Filled);
            }
            finally
            {
                File.Delete(tempFileName);
            }
        }
    }
}