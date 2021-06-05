#!/bin/bash
export LANG=en_US.UTF-8

g_pwd=$(pwd)
g_arg1=$1
g_arg2=$2
g_arg3=$3
g_arg4=$4
g_arg5=$5
g_arg6=$6

g_sys=''
g_install=''
g_update=""
g_upgrade=""
g_remove=''

g_v2="/etc/v2ray-agent"
g_e_url="https://raw.githubusercontent.com/shiqingk/some-codes/master/shell/e.sh"

g_tmp=""

f_help() {
    echo "
    Usage: v0.3
    e [options]
        .             append this shell to alias, then use as: e [options]
        -a            docker ps -a
        -c            cat trojan json config
        -i            docker images
        -ef           ps -ef | grep key | grep key2
        -it           docker exec -it pod shell
        -rn           grep -rni xx
        -net          netstat -ntulp
        -tls          cp crt from $g_pwd to $g_v2/tls/
        
        t             tail -f xxx
        dk            docker 
        fd            find xx -iname xx
        jd            enter jd module
        tg            tail -f trojan-go log
        tj            tail -f trojan log

        cpu           Top 10 programs for cpu usage
        logs          docker logs -f xxx
        mem           Top 10 programs for memery usage
        upd           apt update  | yum update
        upg           apt upgrade | yum upgrade
        
        nohup         run shell with nohup
        update        update current e.sh shell
        mirrors       change system mirrors
    desc:
        you can also download this script on other linux:
            curl $g_e_url -o e.sh
"
}

f_init() {
    case $g_arg1 in
    .)
        shopt -s expand_aliases
        fd=$(grep " e='" ~/.bashrc | grep -v "#" | wc -l)
        if [ $fd -eq 0 ]; then
            echo "alias e='$g_pwd/e.sh'" >>~/.bashrc
        fi
        source ~/.bashrc
        ;;
    -a)
        docker ps -a
        ;;
    -c)
        cat $(f_ps_last_col trojan json)
        ;;
    -i)
        docker images
        ;;
    -ef)
        f_ps $g_arg2 $g_arg3
        ;;
    -it)
        f_docker_exec
        ;;
    -net)
        echo "run: netstat -ntulp"
        netstat -ntulp
        ;;
    -tls)
        cptls
        ;;
    -rn)
        grep -rni "$g_arg2"
        ;;
    t)
        tail -f $g_arg2
        ;;
    dk)
        f_docker
        ;;
    fd)
        find $g_arg2 -iname $g_arg3
        ;;
    jd)
        f_jd
        ;;
    tg)
        f_tail_trojan
        ;;
    tj)
        journalctl -xen -u trojan --no-pager -f
        ;;
    cpu)
        f_cpu_mem 3
        ;;
    mem)
        f_cpu_mem 4
        ;;
    logs)
        docker logs -f $g_arg2
        ;;
    upd)
        echo $g_update
        eval $g_update
        ;;
    upg)
        echo $g_update
        echo $g_upgrade
        eval $g_update
        eval $g_upgrade
        ;;
    mirrors)
        bash <(curl -sSL https://gitee.com/SuperManito/LinuxMirrors/raw/main/ChangeMirrors.sh)
        ;;
    nohup)
        f_nohup
        ;;
    update)
        f_update
        ;;
    test)
        echo "test OK!"
        ;;
    *)
        f_help
        exit 1
        ;;
    esac
}

cptls() {
    if [ ! -d $g_v2 ]; then
        mdir $g_v2
    fi
    if [ ! -d $g_v2/tls/ ]; then
        mdir $g_v2/tls/
    fi
    ls -la $g_pwd/*.crt
    ls -la $g_pwd/*.pem
    cp -f $g_pwd/*.crt $g_v2/tls/
    cp -f $g_pwd/*.pem $g_v2/tls/
}

f_docker() {
    if [ ! -n "$g_arg2" ]; then
        g_arg2=""
    fi
    if [ ! -n "$g_arg3" ]; then
        g_arg3=""
    fi
    if [ ! -n "$g_arg4" ]; then
        g_arg4=""
    fi
    if [ ! -n "$g_arg5" ]; then
        g_arg5=""
    fi
    if [ ! -n "$g_arg6" ]; then
        g_arg6=""
    fi
    docker $g_arg2 $g_arg3 $g_arg4 $g_arg5 $g_arg6
}
f_docker_exec() {
    if [ ! -n "$g_arg3" ]; then
        g_arg3="sh"
    fi
    if [ ! -n "$g_arg4" ]; then
        g_arg4=""
    fi
    docker exec -it $g_arg2 $g_arg3 $g_arg4
}
f_tail_trojan() {
    log_path=$g_v2/trojan/trojan.log
    if [ ! -n "$log_path" ]; then
        journalctl -xen -u trojan-go --no-pager -f
    else
        tail -f $log_path
    fi
}

f_ps() {
    key=$1
    key2=$2

    ps -ef | grep "$key" | grep "$key2" | grep -vE "grep|sh -ef $key"
}

f_ps_last_col() {
    ps -ef | grep $1 | grep $2 | awk '{print $NF}'
}

f_cpu_mem() {
    ps aux | head -1
    ps aux | grep -v PID | sort -rn -k +$1 | head
}

f_update() {
    path=$(cat ~/.bashrc | grep '/e.sh')
    path=${path%?}
    path=${path##*\'}
    echo "$path"
    if [ ! -n "$path" ]; then
        echo "e.sh file not found!"
        exit
    fi
    rm -rf /tmp/e.sh
    curl $g_e_url -o /tmp/e.sh
    sleep 1
    echo "test new script start"
    chmod 777 /tmp/e.sh
    /tmp/e.sh test
    echo "test new script end"
    read -p "is replace $path ?(y/n) $1: " g_tmp
    if [[ $g_tmp =~ "y" ]]; then
        mv -f /tmp/e.sh $path
        cp -f $path /tmp/e.bak.sh
        chmod 777 $path
        echo "update new script success"
    fi
    echo "end"
}

f_check_system() {
    if [[ -n $(find /etc -name "redhat-release") ]] || grep </proc/version -q -i "centos"; then
        mkdir -p /etc/yum.repos.d

        if [[ -f "/etc/centos-release" ]]; then
            centosVersion=$(rpm -q centos-release | awk -F "[-]" '{print $3}' | awk -F "[.]" '{print $1}')

            if [[ -z "${centosVersion}" ]] && grep </etc/centos-release "release 8"; then
                centosVersion=8
            fi
        fi

        g_sys="centos"
        g_install='yum -y install'
        g_update="yum update -y"
        g_upgrade="yum update -y --skip-broken"
        g_remove='yum -y remove'

    elif grep </etc/issue -q -i "debian" && [[ -f "/etc/issue" ]] || grep </etc/issue -q -i "debian" && [[ -f "/proc/version" ]]; then
        if grep </etc/issue -i "8"; then
            debianVersion=8
        fi
        g_sys="debian"
        g_install='apt -y install'
        g_update="apt update"
        g_upgrade="apt upgrade -y"
        g_remove='apt -y autoremove'

    elif grep </etc/issue -q -i "ubuntu" && [[ -f "/etc/issue" ]] || grep </etc/issue -q -i "ubuntu" && [[ -f "/proc/version" ]]; then
        g_sys="ubuntu"
        g_install='apt -y install'
        g_update="apt update"
        g_upgrade="apt upgrade -y"
        g_remove='apt -y autoremove'
    fi

    if [ ! -n "$g_sys" ]; then
        echo 'not support current system!'
        cat /etc/issue
        cat /proc/version
        exit 0
    fi
}

f_jd() {
    echo "Usage:
    1.rebuild jd container
    2.run all jd_*.js with nohup
    "
    read -p "input $1: " g_tmp
    case $g_tmp in
    1)
        f_rebuild_jd
        ;;
    2)
        fd=$(ps -ef | grep 'docker exec jd bash' | grep -vE 'e.sh|grep' | wc -l)
        if [ $fd -gt 0 ]; then
            echo "docker exec job is running"
            return
        fi
        echo "docker exec jd bash -c 'cd /jd/scripts; ls jd_*.js | xargs -i /jd/jd.sh {} now'" >/tmp/jd_run.sh
        chmod 777 /tmp/jd_run.sh
        nohup /tmp/jd_run.sh >/tmp/jd.log 2>&1 &
        echo "nohup finished"
        ;;
    *)
        f_jd
        ;;
    esac
}

f_rebuild_jd() {
    echo "input the path of path, such as this, so input /root/jd 
    and full path like this
        /root/jd
        /root/jd/config
        /root/jd/log
"

    read -p "path $1: " g_tmp

    if [ ! -n "$g_tmp" ]; then
        g_tmp=$PWD
    fi

    if [ ! -n "$g_tmp/config" ]; then
        echo "config folder not exists!"
        f_rebuild_jd
        return
    fi

    rm -rf $g_tmp/log
    mkdir $g_tmp/log

    docker stop jd
    echo "end"
    # docker rm jd

    # PWD=/root/hym/noobx

    # docker run -dit \
    #     -v $PWD/config:/jd/config \
    #     -v $PWD/log:/jd/log \
    #     -v $PWD/scripts:/scripts \
    #     --network=host \
    #     -e ENABLE_HANGUP=true \
    #     -e ENABLE_WEB_PANEL=true \
    #     --name jd \
    #     --hostname jd \
    #     --restart always \
    #     -m 300M --memory-swap -1 \
    # --cpu-period=1000000 --cpu-quota=900000 \
    #     noobx/jd:gitee
    f_jd
}

f_nohup() {
    rm -rf /tmp/tmp.sh
    echo "$g_arg2" >/tmp/tmp.sh
    nohup /tmp/tmp.sh >/tmp/tmp.log 2>&1 &
    echo "nohup end"
}

pass() {
    echo "" >/dev/null
}

f_check_system
f_init
