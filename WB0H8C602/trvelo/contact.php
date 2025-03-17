<?php

//These must be at the top of your script, not inside a function
use PHPMailer\PHPMailer\PHPMailer;
use PHPMailer\PHPMailer\Exception;
use PHPMailer\PHPMailer\SMTP;

// Load Files
require 'PHPMailer/Exception.php';
require 'PHPMailer/PHPMailer.php';
require 'PHPMailer/SMTP.php';

//Create an instance; passing `true` enables exceptions
$mail = new PHPMailer(true);

try {
    //Server settings
    $mail->SMTPDebug = SMTP::DEBUG_SERVER;                      //Enable verbose debug output
    $mail->isSMTP();   

	//Send using SMTP
	$mail->CharSet = "utf-8";// set charset to utf8
	$mail->SMTPAuth = true;// Enable SMTP authentication
	$mail->SMTPSecure = 'tls';// Enable TLS encryption, `ssl` also accepted

	$mail->Host = 'smtp.gmail.com';// Specify main and backup SMTP servers
	$mail->Port = 587;// TCP port to connect to
	$mail->SMTPOptions = array(
		'ssl' => array(
			'verify_peer' => false,
			'verify_peer_name' => false,
			'allow_self_signed' => true
		)
	);	
	
    //Enable SMTP authentication
    
	$mail->Username   = 'bograhost@gmail.com';  //SMTP username
    $mail->Password   = 'pvmk iptj hric blbx ';  //SMTP App password
    
    //Recipients
    $mail->setFrom('bograhost@gmail.com', 'Contact Form'); //Add SMTP Email Address
	$mail->addAddress('azeemrahal5@gmail.com', 'Test Mail Using SMTP'); //  Receive Message Email Address

    //Content
	
	$name = $_POST["name"];
	$email = $_POST["email"];
	$subject = $_POST["subject"];
	$message = $_POST["message"];

	
    $mail->isHTML(true);  //Set email format to HTML
    $mail->Subject    = $subject; //Subject
    $mail->Body    = "Sender Name : $name <br> Email: $email <br> Subject: $subject <br> Message: $message "; //message

    $mail->send();
	
    echo 'Message has been sent';
} catch (Exception $e) {
    echo "Message could not be sent. Mailer Error: {$mail->ErrorInfo}";
}