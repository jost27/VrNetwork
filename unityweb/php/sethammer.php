<?php


if(isset($_POST["hammer"]) && isset($_POST["id"])){

  include'config.php';
  $idc=$_POST["id"];
  $hammer=$_POST["hammer"];
// Check connection
  $conn = new mysqli($servername, $username, $password,$dbname);
  if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
  }
  $sql = "UPDATE users  SET GrabTimesHammer='$hammer' WHERE  ID='$idc'";
  if ($conn->query($sql) === TRUE) {
    echo "New record updated";
  } else {
    echo "Error: " . $sql . "<br>" . $conn->error;
  }
  
  $conn->close();

}


?>