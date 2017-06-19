using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QA.Base.Handlers;
using QA.Base.Interface;

namespace QA.Test
{
    [TestClass]
    public class BaseTest
    {
        [TestInitialize]
        public void Initiaze()
        {
            Bootstrapper.Boot();
        }

        [TestMethod]
        public void TestQA()
        {
            ////
            var paragraph = "Zebras are several species of African equids (horse family) united by their distinctive black and white stripes. Their stripes come in different patterns, unique to each individual. They are generally social animals that live in small harems to large herds. Unlike their closest relatives, horses and donkeys, zebras have never been truly domesticated. There are three species of zebras, the plains zebra, the Grévy's zebra and the mountain zebra. The plains zebra and the mountain zebra belong to the subgenus Hippotigris, but Grévy's zebra is the sole species of subgenus Dolichohippus. The latter resembles an ass, to which it is closely related, while the former two are more horse-like. All three belong to the genus Equus, along with other living equids. The unique stripes of zebras make them one of the animals most familiar to people. They occur in a variety of habitats, such as grasslands, savannas, woodlands, thorny scrublands, mountains, and coastal hills. However, various anthropogenic factors have had a severe impact on zebra populations, in particular hunting for skins and habitat destruction. Grévy's zebra and the mountain zebra are endangered. While plains zebras are much more plentiful, one subspecies, the quagga, became extinct in the late 19th century – though there is currently a plan, called the Quagga Project, that aims to breed zebras that are phenotypically similar to the quagga in a process called breeding back.";
            var Q1 = "Which Zebras are endangered?";
            var Q2 = "What is the aim of the Quagga Project?";
            var Q3 = "Which animals are some of their closest relatives?";
            var Q4 = "Which are the three species of zebras?";
            var Q5 = "Which subgenus do the plains zebra and the mountain zebra belong to?";
            var answerList = "subgenus Hippotigris;the plains zebra, the Grévy's zebra and the mountain zebra;horses and donkeys;aims to breed zebras that are phenotypically similar to the quagga;Grévy's zebra and the mountain zebra";
            ////
            var A1 = "Grévy's zebra and the mountain zebra";
            var A2 = "aims to breed zebras that are phenotypically similar to the quagga";
            var A3 = "horses and donkeys";
            var A4 = "the plains zebra, the Grévy's zebra and the mountain zebra";
            var A5 = "subgenus Hippotigris";
            ////

            var parser = UnityHandler.Instance.Resolve<IBaseParser>();
            parser.Input(TestExtension.Join(paragraph, Q1, Q2, Q3, Q4, Q5, answerList));
            string actual = parser.Process();

            Assert.AreEqual(TestExtension.Join(A1, A2, A3, A4, A5), actual);
        }

        [TestMethod]
        public void TestQA2()
        {
            ////
            var paragraph = "The first practical ICs were invented by Jack Kilby at Texas Instruments and Robert Noyce at Fairchild Semiconductor.[47] Kilby recorded his initial ideas concerning the integrated circuit in July 1958, successfully demonstrating the first working integrated example on 12 September 1958.[48] In his patent application of 6 February 1959, Kilby described his new device as a body of semiconductor material...wherein all the components of the electronic circuit are completely integrated.[49][50] Noyce also came up with his own idea of an integrated circuit half a year later than Kilby.[51] His chip solved many practical problems that Kilby's had not. Produced at Fairchild Semiconductor, it was made of silicon, whereas Kilby's chip was made of germanium. This new development heralded an explosion in the commercial and personal use of computers and led to the invention of themicroprocessor.While the subject of exactly which device was the first microprocessor is contentious, partly due to lack of agreement on the exact definition of the term 'microprocessor', it is largely undisputed that the first single-chip microprocessor was the Intel 4004,[52] designed and realized byTed Hoff, Federico Faggin, and Stanley Mazor atIntel.[53]";
            var Q1 = "who invented the first practical ICs?";
            var Q2 = "How did Kilby describe his new device?";
            var Q3 = "what was kilby's chip made of?";
            var Q4 = "what was the first single-chip microprocessor?";
            var Q5 = "who was the designer of Intel 4004?";
            var answerList = "Ted Hoff, Federico Faggin, and Stanley Mazor;Intel 4004;as a body of semiconductor material...wherein all the components of the electronic circuit are completely integrated;germanium;Jack Kilby";
            ////
            var A1 = "Jack Kilby";
            var A2 = "as a body of semiconductor material...wherein all the components of the electronic circuit are completely integrated";
            var A3 = "germanium";
            var A4 = "Intel 4004";
            var A5 = "Ted Hoff, Federico Faggin, and Stanley Mazor";
            ////

            var parser = UnityHandler.Instance.Resolve<IBaseParser>();
            parser.Input(TestExtension.Join(paragraph, Q1, Q2, Q3, Q4, Q5, answerList));
            string actual = parser.Process();

            Assert.AreEqual(TestExtension.Join(A1, A2, A3, A4, A5), actual);
        }
    }
}
