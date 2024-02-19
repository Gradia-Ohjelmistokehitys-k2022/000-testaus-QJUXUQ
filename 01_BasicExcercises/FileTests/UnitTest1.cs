using System.Reflection;

namespace FileTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestClass]
        public class FileUnitTests
        {
            [TestMethod]
            public void ReadFile_ReturnsListOfSettings_IfFileIsNotEmpty()
            {
                //Arrange
                List<string> systemConfig=new List<string>();
                string winDir = "C:\\Windows";
                string path = "\\system.ini";
                //Act
                systemConfig = FileOperations.File.ReadFile(systemConfig, winDir, path);
                //Assert
                Assert.IsTrue(systemConfig.Count > 0); 
            }
            [TestMethod]
            public void ReadFile_ReturnsListOfSettings_IfNoAcess()
            {
                //Arrange
                List<string> systemConfig = new List<string>();
                string winDir = "C:\\Windows";
                string path = "";
                //Act &
                //Assert
                Assert.ThrowsException<UnauthorizedAccessException>(()=>FileOperations.File.ReadFile(systemConfig,winDir,path));
            }
            [TestMethod]
            public void ReadFile_ReturnsListOfSettings_IfFileIsNotThere()
            {
                //Arrange
                List<string> systemConfig = new List<string>();
                string winDir = "C:\\Windows";
                string path = "\\iamnothere";
                //Act & Assert
             
                Assert.ThrowsException<FileNotFoundException>(() => FileOperations.File.ReadFile(systemConfig, winDir, path));

            }
        }
    }
}