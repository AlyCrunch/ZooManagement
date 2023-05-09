using System;
using System.Collections.Generic;
using System.Text;
using ZooManagement;

namespace ZooManagementTest
{
    internal class FileManagerPrices : IFileManager
    {
        public string Read(string filePath)
        {
            return $@"Meat=12.56
Fruit=5.60";
        }
    }
    internal class FileManagerTypes : IFileManager
    {
        public string Read(string filePath)
        {
            return $@"Lion;0.10;meat;
Tiger;0.09;meat;
Giraffe;0.08;fruit;
Zebra;0.08;fruit;
Wolf;0.07;both;90%
Piranha;0.5;both;50%
";
        }
    }
    internal class FileManagerAnimals : IFileManager
    {
        public string Read(string filePath)
        {
            return $@"<Zoo>
                          <Lions>
                            <Lion name='Simba' kg='160'/>
                            <Lion name='Nala' kg='172'/>
                            <Lion name='Mufasa' kg='190'/>
                          </Lions>
                          <Giraffes>
                            <Giraffe name='Hanna' kg='200'/>
                            <Giraffe name='Anna' kg='202'/>
                            <Giraffe name='Susanna' kg='199'/>
                          </Giraffes>
                          <Tigers>
                            <Tiger name='Dante' kg='150'/>
                            <Tiger name='Asimov' kg='142'/>
                            <Tiger name='Tolkien' kg='139'/>
                          </Tigers>
                          <Zebras>
                            <Zebra name='Chip' kg='100'/>
                            <Zebra name='Dale' kg='62'/>
                          </Zebras>
                          <Wolves>
                            <Wolf name='Pin' kg='78'/>
                            <Wolf name='Pon' kg='69'/>
                          </Wolves>
                          <Piranhas>
                            <Piranha name='Anastasia' kg='0.5'/>
                          </Piranhas>
                        </Zoo>
                        ";
        }
    }
}
