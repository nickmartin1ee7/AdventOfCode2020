using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Library.Day8
{
    public class Day8 : BaseSolution
    {
        private IEnumerable<string> _rawData;

        public Day8()
        {
            _rawData = ReadLines(GetType());
        }

        public override string SilverStar()
        {
            var lmc = new Computer();
            lmc.RunProgram(_rawData);
            return $"{lmc.Accumulator}";
        }

        public override string GoldStar()
        {
            throw new System.NotImplementedException();
        }

    }

    public class Computer
    {
        private Dictionary<int, Instruction> _programInstructions = new Dictionary<int, Instruction>();
        private InstructionRegister _ioc = new InstructionRegister();

        public int Accumulator { get; set; }

        public void RunProgram(IEnumerable<string> programData)
        {
            ProcessProgramData(programData);
            ExecuteProgramInstructions();
        }

        private void ExecuteProgramInstructions()
        {
            do
            {
                if (_programInstructions.TryGetValue(_ioc.InstructionPointer, out Instruction targetInstruction))
                {
                    if (!ExecuteInstruction(targetInstruction))
                        break;
                }
                else
                {
                    throw new AccessViolationException($"Instruction pointer({_ioc.InstructionPointer}) outside program data({_programInstructions.Count})");
                }
            } while (_ioc.InstructionPointer < _programInstructions.Count);
        }

        private void ProcessProgramData(IEnumerable<string> programData)
        {
            var data = programData.ToList();
            for (int i = 0; i < data.Count; i++)
            {
                _programInstructions.Add(i, new Instruction(data[i]));
            }
        }

        private bool ExecuteInstruction(Instruction instruction)
        {
            try
            {
                _ioc.CurrentInstruction = instruction;
            }
            catch (Exception)
            {
                return false;
            }

            switch (_ioc.CurrentInstruction.OpCode)
            {
                case OPCODES.nop:
                    // Waste time
                    break;
                case OPCODES.jmp:
                    _ioc.InstructionPointer += _ioc.CurrentInstruction.Value - 1;
                    break;
                case OPCODES.acc:
                    Accumulator += _ioc.CurrentInstruction.Value;
                    break;
            }

            _ioc.InstructionPointer++;
            return true;
        }
    }

    public class InstructionRegister
    {
        private List<Instruction> _history = new List<Instruction>();
        private Instruction _currentInstruction;

        public Instruction CurrentInstruction
        {
            get => _currentInstruction;
            set
            {
                _history.Add(value);
                _currentInstruction = value;
                CheckForInfiniteLoop();
            }
        }

        public int InstructionPointer { get; set; }

        private void CheckForInfiniteLoop()
        {
            if (_history
                .Count(i => i
                    .Equals(CurrentInstruction)) > 1)
                throw new Exception("Recursion detected!");
        }
    }

    public class Instruction
    {
        public OPCODES OpCode { get; }
        public int Value { get; }
        
        public Instruction(string rawInstructon)
        {
            var s = rawInstructon.Split(' ');
            OpCode = Enum.Parse<OPCODES>(s[0]);
            Value = int.Parse(s[1]
                .Replace('+',' '));
        }

        public override string ToString() =>
            $"{OpCode} {Value}";
    }

    public enum OPCODES
    {
        nop,
        jmp,
        acc
    }
}
