#!/bin/bash

data_directory="data"
base_url="https://register.ofqual.gov.uk/Home/Download?category="

qualifications_directory="${data_directory}/qualifications"
exam_boards_directory="${data_directory}/exam_boards"

qualifications_url="${base_url}Qualifications"
exam_boards_url="${base_url}Organisations"

mkdir -p ${qualifications_directory};
mkdir -p ${exam_boards_directory};

date=$(date '+%Y%m%d-%H%M');

function processFile(){
  dir=$1
  url=$2

  # Fetch latest exam_boards
  echo "Downloading latest CSV..."
  wget -q --show-progress -O ${dir}/temp.csv ${url}
  #curl -s -o ${dir}/temp.csv ${url}

  # If latest doesn't exist, save to latest
  if [ ! -f ${dir}/latest.csv ]; then
    tail -n +2 ${dir}/temp.csv > ${dir}/${date}.csv
    cp ${dir}/${date}.csv ${dir}/latest.csv
  else
    echo "Comparing to latest version..."
    # Otherwise compare latest.csv to fetched csv
    tail -n +2 ${dir}/temp.csv | comm -13 ${dir}/latest.csv - > ${dir}/${date}.csv

    # If there is no difference, then delete empty file
    if [ ! -s ${dir}/${date}.csv ]; then
      rm -f ${dir}/${date}.csv
    else
      echo "Latest version updated!"
    fi
  fi
  rm ${dir}/temp.csv
}

echo "Processing exam boards..."
processFile ${exam_boards_directory} ${exam_boards_url}

echo "Processing qualifications..."
processFile ${qualifications_directory} ${qualifications_url}
