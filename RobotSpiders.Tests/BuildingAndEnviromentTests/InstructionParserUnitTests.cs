namespace RobotSpiders.Tests.BuildingAndEnviromentTests
{
    using NUnit.Framework;

    using Patterns.State;

    using RobotSpiders.Movement;

    internal class InstructionParserUnitTests
    {
        private InstructionParser _instructionParser;

        [SetUp]
        public void Init()
        {
            this._instructionParser = new InstructionParser();    
        }

        [Test]
        public void Parse_LeftInstruction_ReturnsCommandLeft()
        {
            var result = this._instructionParser.Parse('L');
            Assert.AreEqual(Command.Left, result);
        }

        [Test]
        public void Parse_RightInstruction_ReturnsCommandLeft()
        {
            var result = this._instructionParser.Parse('R');
            Assert.AreEqual(Command.Right, result);
        }

        [Test]
        public void Parse_ForwardInstruction_ReturnsCommandForward()
        {
            var result = this._instructionParser.Parse('F');
            Assert.AreEqual(Command.Forward, result);
        }

        [Test]
        public void Parse_LowerCasedInstruction_ThrowsArgumentException()
        {
            Assert.That(() => this._instructionParser.Parse('f'), Throws.ArgumentException);
        }

        [Test]
        public void Parse_InVAlidInstruction_ThrowsArgumentException()
        {
            Assert.That(() => this._instructionParser.Parse('T'), Throws.ArgumentException);
        }
    }
}