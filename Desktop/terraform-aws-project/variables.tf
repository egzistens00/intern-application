variable "region" {
  default = "ap-northeast-1"
}

variable "ami_id" {
  description = "Ubuntu AMI ID"
  default     = "ami-0f3c7d07486cad139"
}

variable "instance_type" {
  default = "t2.micro"
}

variable "bucket_name" {
  description = "Unique name for your S3 bucket"
  type        = string
}
