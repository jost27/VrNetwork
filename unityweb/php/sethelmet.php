<?php


if(isset($_POST["usehelmet"]) && isset($_POST["id"])){

  include'config.php';
  $idc=$_POST["id"];
  $helmet=$_POST["usehelmet"];
// Check connection
  $conn = new mysqli($servername, $username, $password,$dbname);
  if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
  }
  $sql = "UPDATE users  SET UseHelmet=$helmet WHERE  ID='$idc'";
  if ($conn->query($sql) === TRUE) {
    echo "New record updated";
  } else {
    echo "Error: " . $sql . "<br>" . $conn->error;
  }
  
  $conn->close();

}

?>