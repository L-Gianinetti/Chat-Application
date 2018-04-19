-- MySQL Script generated by MySQL Workbench
-- 02/26/18 11:11:15
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

-- -----------------------------------------------------
-- Schema ChatApplication
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `ChatApplication` DEFAULT CHARACTER SET utf8 ;
USE `ChatApplication` ;

-- -----------------------------------------------------
-- Table `ChatApplication`.`User`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ChatApplication`.`User` (
  `idUser` INT NOT NULL AUTO_INCREMENT,
  `userName` VARCHAR(45) NULL,
  `userFirstName` VARCHAR(45) NULL,
  `userPseudonym` VARCHAR(45) NOT NULL,
  `userDescription` TEXT(1000) NULL,
  `userPassword` VARCHAR(100) NOT NULL,
  `userPhoto` VARCHAR(60) NULL,
  PRIMARY KEY (`idUser`))
ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `ChatApplication`.`Contact`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ChatApplication`.`Contact` (
  `idContact` INT NOT NULL AUTO_INCREMENT,
  `contactNote` TEXT(300) NULL,
  `fkUser` INT NOT NULL,
  `fkUserContact` INT NOT NULL,
  PRIMARY KEY (`idContact`),
  INDEX `fk_Contact_User1_idx` (`fkUser` ASC),
  CONSTRAINT `fk_Contact_User1`
    FOREIGN KEY (`fkUser`)
    REFERENCES `ChatApplication`.`User` (`idUser`),
    FOREIGN KEY (`fkUserContact`)
    REFERENCES `ChatApplication`.`User` (`idUser`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;






-- -----------------------------------------------------
-- Table `ChatApplication`.`Category`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ChatApplication`.`Category` (
  `idCategory` INT NOT NULL AUTO_INCREMENT,
  `categoryName` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`idCategory`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ChatApplication`.`Discussion`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ChatApplication`.`Discussion` (
  `idDiscussion` INT NOT NULL AUTO_INCREMENT,
  `discussionName` VARCHAR(45) NOT NULL,
  `publique` BOOLEAN NOT NULL,
  PRIMARY KEY (`idDiscussion`)
  )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ChatApplication`.`Message`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ChatApplication`.`Message` (
  `idMessage` INT NOT NULL AUTO_INCREMENT,
  `messageContent` TEXT(1000) NOT NULL,
  `sendTime` DATETIME NOT NULL,
  `fkDiscussion` INT NOT NULL,
  `fkUser` INT NOT NULL,
  PRIMARY KEY (`idMessage`),
  INDEX `fk_Message_Discussion1_idx` (`fkDiscussion` ASC),
  INDEX `fk_Message_User1_idx` (`fkUser` ASC),
  CONSTRAINT `fk_Message_Discussion1`
    FOREIGN KEY (`fkDiscussion`)
    REFERENCES `ChatApplication`.`Discussion` (`idDiscussion`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Message_User1`
    FOREIGN KEY (`fkUser`)
    REFERENCES `ChatApplication`.`User` (`idUser`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `ChatApplication`.`Discussion_has_Category`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ChatApplication`.`Discussion_has_Category` (
  `fkDiscussion` INT NOT NULL,
  `fkCategory` INT NOT NULL,
  PRIMARY KEY (`fkDiscussion`, `fkCategory`),
  INDEX `fk_Discussion_has_Category_Category1_idx` (`fkCategory` ASC),
  INDEX `fk_Discussion_has_Category_Discussion1_idx` (`fkDiscussion` ASC),
  CONSTRAINT `fk_Discussion_has_Category_Discussion1`
    FOREIGN KEY (`fkDiscussion`)
    REFERENCES `ChatApplication`.`Discussion` (`idDiscussion`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Discussion_has_Category_Category1`
    FOREIGN KEY (`fkCategory`)
    REFERENCES `ChatApplication`.`Category` (`idCategory`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ChatApplication`.`DemandesContacts`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ChatApplication`.`DemandesContacts` (
  `idDemandesContactsEnvoyees` INT NOT NULL AUTO_INCREMENT,
  `fkUser` INT NOT NULL,
  `fkUserContact` INT NOT NULL,
  `Statut` ENUM('Recue', 'Envoyee') NOT NULL,
  PRIMARY KEY (`idDemandesContactsEnvoyees`),
  INDEX `fk_DemandesContactsEnvoyees_User1_idx` (`fkUser` ASC),
  CONSTRAINT `fk_DemandesContactsEnvoyees_User1`
    FOREIGN KEY (`fkUser`)
    REFERENCES `ChatApplication`.`User` (`idUser`),
    FOREIGN KEY (`fkUserContact`)
    REFERENCES `ChatApplication`.`User` (`idUser`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ChatApplication`.`Archives`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ChatApplication`.`Archives` (
  `idArchives` INT NOT NULL AUTO_INCREMENT,
  `fkDiscussion` INT NOT NULL,
  `fkUser` INT NOT NULL,
  `fkAdministrateur` INT NOT NULL,
  PRIMARY KEY (`idArchives`),
  INDEX `fk_Archives_Discussion1_idx` (`fkDiscussion` ASC),
  CONSTRAINT `fk_Archives_Discussion1`
    FOREIGN KEY (`fkDiscussion`)
    REFERENCES `ChatApplication`.`Discussion` (`idDiscussion`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
    FOREIGN KEY (`fkUser`)
	REFERENCES `ChatApplication`.`User` (`idUser`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
	FOREIGN KEY(`fkAdministrateur`)
    REFERENCES `ChatApplication`.`User` (`idUser`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ChatApplication`.`ParticipationDiscussions`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ChatApplication`.`ParticipationDiscussions` (
  `idParticipationDiscussions` INT NOT NULL AUTO_INCREMENT,
  `fkUser` INT NOT NULL,
  `fkDiscussion` INT NOT NULL,
  `fkAdministrateur` INT NOT NULL,
  `statut` ENUM('En attente', 'Participe', 'Supprimé') NOT NULL,
  PRIMARY KEY (`idParticipationDiscussions`),
  INDEX `fk_ParticipationDiscussions_User1_idx` (`fkUser` ASC),
  INDEX `fk_ParticipationDiscussions_Discussion1_idx` (`fkDiscussion` ASC),
  CONSTRAINT `fk_ParticipationDiscussions_User1`
    FOREIGN KEY (`fkUser`)
    REFERENCES `ChatApplication`.`User` (`idUser`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_ParticipationDiscussions_Discussion1`
    FOREIGN KEY (`fkDiscussion`)
    REFERENCES `ChatApplication`.`Discussion` (`idDiscussion`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
    FOREIGN KEY(`fkAdministrateur`)
    REFERENCES `ChatApplication`.`User` (`idUser`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    )
ENGINE = InnoDB;


-- Category
insert into Category (idCategory, categoryName) values (1, 'Sport');
insert into Category (idCategory, categoryName) values (2, 'Politique');
insert into Category (idCategory, categoryName) values (3, 'Environnement');
insert into Category (idCategory, categoryName) values (4, 'Dietetique');
insert into Category (idCategory, categoryName) values (5, 'Litterature');
insert into Category (idCategory, categoryName) values (6, 'Cinema');
insert into Category (idCategory, categoryName) values (7, 'Histoire');
insert into Category (idCategory, categoryName) values (8, 'France');
insert into Category (idCategory, categoryName) values (9, 'Vacances');
insert into Category (idCategory, categoryName) values (10, 'Programmation');
