<?php

    $con = mysqli_connect('localhost', 'root', '', 'zmija');

    if (mysqli_connect_errno()){
        echo "1";
        exit();
    }

    $username = $_POST["name"];
    $password = $_POST["password"];

    $namecheckquerry = "SELECT username FROM korisnici WHERE username = '" . $username . "';";
   
    $namecheck = mysqli_query($con, $namecheckquerry) or die("2");

    if (mysqli_num_rows ($namecheck) > 0){
        echo "3";
        exit();
    }

    $insertuserquerry = "INSERT INTO korisnici (username, password) VALUES ('" . $username . "','" . $password . "');";
    mysqli_query($con, $insertuserquerry) or die("4");

    echo ('0');





?>