using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogStandert
{
    public class LOG
    {
        public string Name { get; }         //  имя устройства ip
        public string Key { get; }          //  ключ лога создаются почередно если он совпадает то лог перезаписывается //ToDo история лога  
        public string Id { get => Key; }    //  ключ лога создаются почередно если он совпадает то лог перезаписывается //ToDo история лога  
        public string Time { get; }         //  время создания 
        public string Type { get; }         //  тип 
        public string Header { get; }       //  заголовок
        public string Text_Stack { get; }   //  текст лога (стек)

        public LOG(
            string name, string key, string time,
            string type, string header, string text_Stack)
        {
            Name = name;
            Key = key;
            Time = time;
            Type = type;
            Header = header;
            Text_Stack = text_Stack;
        }

        public override string ToString()
        {
            return $"{Name}\t{Key}\t{Time}\t{Type}\t{Header}\t{Text_Stack}";
        }
        /*
         * парсеры : json, xml
         */
    }
}
