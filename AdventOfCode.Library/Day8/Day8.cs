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
            // Populates _programInstructions
            ProcessProgramData(programData);

            // Executes _programInstructions acting on Accumulator
            ExecuteProgramInstructions();
        }

        private void ExecuteProgramInstructions()
        {
            do // For each instruction
            {
                if (_programInstructions.TryGetValue(_ioc.InstructionPointer, out Instruction targetInstruction))   // Get instruction at InstructionPointer
                {
                    if (!ExecuteInstruction(targetInstruction)) // Execute instruction
                        break;  // If execution ends prematurely
                }
                else // Invalid instruction pointer
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
            //if (instruction.Opcode == OPCODES.jmp)
            //{
            //    stateBeforeJump = _ioc;
            //}

            try
            {
                _ioc.CurrentInstruction = instruction;
            }
            catch (StackOverflowException)
            {
                if (_nopRecursion)
                {
                    instruction.Opcode = OPCODES.nop;
                    _ioc.CurrentInstruction = instruction;
                }
                else
                {
                    return false;
                }
                
            }

            switch (_ioc.CurrentInstruction.Opcode)
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
        private List<Instruction> _historicalInstructions = new List<Instruction>();
        private Instruction _currentInstruction;

        public Instruction CurrentInstruction
        {
            get => _currentInstruction;
            set
            {
                CheckForInfiniteLoop(value);
                _historicalInstructions.Add(value);
                _currentInstruction = value;
            }
        }

        public int InstructionPointer { get; set; }
        
        private void CheckForInfiniteLoop(Instruction futureInstruction)
        {
            var localHistory = _historicalInstructions;
            localHistory.Add(futureInstruction);
            if (localHistory
                .Count(i => i
                    .Equals(CurrentInstruction)) > 1)
                throw new StackOverflowException("Recursion detected!");
        }
    }

    public class Instruction
    {
        public OPCODES Opcode { get; set; }
        public int Value { get; }
        
        public Instruction(string rawInstructon)
        {
            var s = rawInstructon.Split(' ');
            Opcode = Enum.Parse<OPCODES>(s[0]);
            Value = int.Parse(s[1]
                .Replace('+',' '));
        }

        public override string ToString() =>
            $"{Opcode} {Value}";
    }

    public enum OPCODES
    {
        nop,
        jmp,
        acc
    }
}
