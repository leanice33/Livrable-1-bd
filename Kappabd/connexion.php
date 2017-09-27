<html>

	<head>
		<link rel="stylesheet" type="text/css" href="FormStyles.css">
		<style type="text/css">
		</style>
	</head>
	<body class="Background">
	
		
	
		
		<ul id='couleur'>
		  <li><a  href="index.php">Home</a></li>
		  <li><a  href="liste.php">News</a></li>
		  <li><a  href="#contact">Contact</a></li>
		  <li style="float:right"><a  href="Connexion.php">Connexion</a></li>
		</ul>

			
		<div class="auto-style3" style="background-color: #333333;">
			
		 <form method="post">

			Nom: <br>
			<input type="text" placeholder="entrez votre pr&eacute;nom" name="nom"> <br>
			Mot de passe: <br><br>
			<input type="text" placeholder="entrez votre mot de passe" name="mdp1"> <br>
			
			<input type="submit" name="soumettre">
			<hr>
			Pas inscrit? <p><a href="Inscription.php">Inscrivez-vous!</a></p>		
			
			
		  <?php
			try
			{
				$bdd = new PDO('mysql:host=localhost;dbname=Kappabd;charset=utf8', 'Kappa', 'Kappa');
			    
			   }
			 
			   catch (PDOException $e)
			{
			       echo('Erreur de connexion: ' . $e->getMessage());
			       
			       exit();
			        
			} 
			if(isset($_POST["soumettre"]))
			{
				
	
				$nom = $_POST["nom"]; 				
				$mdp1 = $_POST["mdp1"];
				
				try
				{
					$bdd = new PDO('mysql:host=localhost;dbname=Kappabd;charset=utf8', 'Kappa', 'Kappa');
				  	$stm = $bdd ->prepare("CALL VerificationMDP(?)", array(PDO::ATTR_CURSOR, PDO::CURSOR_FWDONLY));

					$value = $nom;
					$stm->bindParam(1, $value); 
					
					// appel de la procÃ©dure stockÃ©e
					$stm->execute();
					
					
					while ($donnees = $stm->fetch())
					{
						if($donnees[4] == $mdp1)
						{
							session_start();
							
							$_SESSION["nom"] = $_POST["nom"];
							$_SESSION["mdp1"] = $_POST["mdp1"];
							$_SESSION['isLogged'] = true;
							
							if($donnees[3] == 1)
							{
							header("Location:siteAdmin.php");
							}
							else
							{
							header("Location:site.php");
							}
							

						}
						else
						 {
						 echo ('Le nom ou le mot de passe est invalide');
						 }

					}
					

					$stm->closeCursor();
					
				   }
				 
				   catch (PDOException $e)
				{
				       echo('Erreur de connexion: ' . $e->getMessage());
				       
				       exit();
				        
				} 

				
								
			}

			  
		 ?>	

		 </form>
		
		</div>
		
	</body>
	
</html>