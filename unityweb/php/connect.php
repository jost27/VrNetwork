<?php


if(isset($_POST["nombre"]) ){
include'config.php';
 
$name=$_POST["nombre"];
// Create connection


// Check connection
  $conn = new mysqli($servername, $username, $password,$dbname);
  if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
  }
  $sql = "INSERT INTO `users`(`User`,  `GrabTimesHammer`, `UseHelmet`, `finishTime`) 
  VALUES ('$name','0','0','0')";
  if ($conn->query($sql) === TRUE) {
    echo "New record created successfully";
  } else {
    echo "Error: " . $sql . "<br>" . $conn->error;
  }
  
  $conn->close();

}


?>

