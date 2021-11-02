<?php
        include'config.php';

        $conn = new mysqli($servername, $username, $password,$dbname);
        if ($conn->connect_error) {
            die("0");
        }
        Echo"1";
        $conn->close();
        ?>
