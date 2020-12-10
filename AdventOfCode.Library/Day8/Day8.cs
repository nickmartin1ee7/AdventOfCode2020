using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

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
            var lmc = new Computer(false);
            lmc.RunProgram(_rawData);
            return $"{lmc.Accumulator}";
        }

        public override string GoldStar()
        {
            var lmc = new Computer(true);
            lmc.RunProgram(_rawData);
            return $"{lmc.Accumulator}";
        }

    }

    public class Computer
    {
        private Dictionary<int, Instruction> _programInstructions;
        private InstructionRegister _ioc;
        private bool _nopRecursion;

        public int Accumulator { get; set; }

        public Computer(bool fixRecursion)
        {
            _programInstructions = new Dictionary<int, Instruction>();
            _ioc = new InstructionRegister();
            _nopRecursion = fixRecursion;
        }

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
                if (!_nopRecursion)
                {
                    return false;
                }

                _ioc.RollBackInstruction();
                _ioc.CurrentInstruction.OpCode = OPCODES.nop;
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

        private List<int> _previousInstructionPointers = new List<int>();
        private int _instructionPointer;

        public int InstructionPointer
        {
            get => _instructionPointer;
            set
            {
                _previousInstructionPointers.Add(_instructionPointer);
                _instructionPointer = value;
            }
        }

        private void CheckForInfiniteLoop()
        {
            if (_history
                .Count(i => i
                    .Equals(CurrentInstruction)) > 1)
                throw new Exception("Recursion detected!");
        }

        public void RollBackInstruction()
        {
            var previous = _history.Count - 2;
            InstructionPointer = _previousInstructionPointers[^2]+1;
            _currentInstruction = _history[previous];
        }
    }

    public class Instruction
    {
        public OPCODES OpCode { get; set; }
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
