using Moq;
using NoteContracs;

namespace MyNoteProcessor.Tests
{
    public class NoteProcessorTests
    {
        [Fact]
        public void ReadALLFromBD()
        {
            var repoMock = new Mock<INoteProcessor>();
            repoMock.Setup(rep => rep.ReadALLFromBD()).Returns(GetTestNotes());
            var allNotesFromMoc = repoMock.Object.ReadALLFromBD().ToList();
            Assert.Equal(4, allNotesFromMoc.Count()); 
        }

        private List<MyNote> GetTestNotes ()
        {
            return new List<MyNote>
            {
                new MyNote(){Id =1, Name = "Relax", Priority =100, Value="Have a nice day"},
                new MyNote(){Id =2, Name = "Good job", Priority =10, Value="Have a nice day"},
                new MyNote(){Id =3, Name = "Fantastic", Priority =80, Value="Have a nice day"},
                new MyNote(){Id =4, Name = "Super", Priority =90, Value="Have a nice day"},
            };
        }
    }
}