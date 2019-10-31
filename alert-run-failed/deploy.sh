#!/bin/bash

##########################################################################
##  Deploys the sample function
##
##  Takes 2 parameters:
##
##  1- Name of resource group
##  2- Storage Account Name

rg=$1
storage=$2

echo "Resource group:  $rg"
echo "Storage Account Name:  $storage"

echo
echo "Deploying ARM template"

az group deployment create -n "deploy-$(uuidgen)" -g $rg \
    --template-file deploy.json \
    --parameters \
    storageAccountName=$storage

